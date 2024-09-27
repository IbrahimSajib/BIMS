using BIMS.DataAccess.ViewModels.Auth.UserManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.Services.IService.Auth
{
    public interface IUserManagementService
    {
        Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
        Task<IdentityUser> GetUserByIdAsync(string id);
        Task<IdentityResult> UpdateUserAsync(UserVM model);
        Task<IdentityResult> DeleteUserAsync(string id);
    }
}
