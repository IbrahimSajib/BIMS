using BIMS.DataAccess.ViewModels.Auth.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAccountService
{
    Task<IdentityResult> RegisterUserAsync(RegisterVM model);
    Task<bool> LoginUserAsync(LoginVM model);
    Task LogoutUserAsync();
}
