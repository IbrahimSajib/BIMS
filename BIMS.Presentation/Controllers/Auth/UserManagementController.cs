using BIMS.DataAccess.ViewModels.Auth.UserManagement;
using BIMS.Services.IService.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BIMS.Presentation.Controllers.Auth
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(IUserManagementService userService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new UserVM { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserVM model)
        {
            var result = await _userService.UpdateUserAsync(model);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("UserList");
        }

        //Add Or Remove Roles From User
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ManageRolesOfUser(string userId)
        {
            ViewBag.userId = userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.userEmail = user.Email;
            var model = new List<RolesOfUserVM>();

            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new RolesOfUserVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        //Add Or Remove Roles From User
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> ManageRolesOfUser(List<RolesOfUserVM> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("UserList");
        }
    }

}
