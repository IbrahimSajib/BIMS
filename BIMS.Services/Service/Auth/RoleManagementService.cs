using BIMS.DataAccess.IRepository.Auth;
using BIMS.DataAccess.ViewModels.Auth.RoleManagement;
using BIMS.Services.IService.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.Services.Service.Auth
{
    public class RoleManagementService : IRoleManagementService
    {
        private readonly IRoleManagementRepository _roleRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleManagementService(IRoleManagementRepository roleRepository, UserManager<IdentityUser> userManager)
        {
            _roleRepository = roleRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<IdentityRole> GetRoleByIdAsync(string id)
        {
            return await _roleRepository.GetRoleByIdAsync(id);
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var identityRole = new IdentityRole { Name = roleName };
            return await _roleRepository.CreateRoleAsync(identityRole);
        }

        public async Task<IdentityResult> UpdateRoleAsync(RoleVM model)
        {
            var role = await _roleRepository.GetRoleByIdAsync(model.Id);
            if (role == null) return IdentityResult.Failed(new IdentityError { Description = "Role not found." });

            role.Name = model.RoleName;
            return await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null) return IdentityResult.Failed(new IdentityError { Description = "Role not found." });

            return await _roleRepository.DeleteRoleAsync(role);
        }

        public async Task<List<UsersInRoleVM>> GetUsersInRoleAsync(string roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            if (role == null) return null;

            var usersInRole = new List<UsersInRoleVM>();
            foreach (var user in _userManager.Users)
            {
                var userRole = new UsersInRoleVM
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                };
                usersInRole.Add(userRole);
            }
            return usersInRole;
        }

        public async Task<IdentityResult> ManageUsersInRoleAsync(List<UsersInRoleVM> model, string roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            if (role == null) return IdentityResult.Failed(new IdentityError { Description = "Role not found." });

            foreach (var userModel in model)
            {
                var user = await _userManager.FindByIdAsync(userModel.UserId);
                IdentityResult result = null;

                if (userModel.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!userModel.IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }

                if (result != null && !result.Succeeded)
                {
                    return result; // Return the first failure result
                }
            }

            return IdentityResult.Success; // Return success if all operations succeeded
        }

    }
}
