using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.Data
{
    public class BIMSDbContext : IdentityDbContext
    {
        public BIMSDbContext(DbContextOptions<BIMSDbContext> options) : base(options)
        {
        }
    }
}
