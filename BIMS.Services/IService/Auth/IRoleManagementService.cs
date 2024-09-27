using BIMS.DataAccess.ViewModels.Auth.RoleManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.Services.IService.Auth
{
    public interface IRoleManagementService
    {
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<IdentityRole> GetRoleByIdAsync(string id);
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> UpdateRoleAsync(RoleVM model);
        Task<IdentityResult> DeleteRoleAsync(string id);
        Task<List<UsersInRoleVM>> GetUsersInRoleAsync(string roleId);
        Task<IdentityResult> ManageUsersInRoleAsync(List<UsersInRoleVM> model, string roleId);
    }
}
