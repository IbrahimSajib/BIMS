using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.ViewModels.Auth.UserManagement
{
    public class UserVM
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
