using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMS.DataAccess.Data
{
    public static class SeedDataExtensions
    {
        public static void SeedRole(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "70cecf66-f00e-406f-ae29-0feb2183689c",
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                },
                new IdentityRole
                {
                    Id = "f672f1be-450b-4899-b9a5-13a0ff856015",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
                );
        }

        //Seed User
        public static void SeedUser(this ModelBuilder builder)
        {
            //PasswordHasher
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

            //Creating User
            var user1 = new IdentityUser
            {
                Id = "c02f71c8-a822-4b3a-900c-5c62478b32f0",
                UserName = "superadmin@bims.com",
                NormalizedUserName = "SUPERADMIN@BIMS.COM",
                Email = "superadmin@bims.com",
                NormalizedEmail = "SUPERADMIN@BIMS.COM",
            };
            user1.PasswordHash = ph.HashPassword(user1, "Sa@123"); //Set user password

            var user2 = new IdentityUser
            {
                Id = "4b9d054d-bcb0-475e-96be-7e07d5ee3b85",
                UserName = "admin@bims.com",
                NormalizedUserName = "ADMIN@BIMS.COM",
                Email = "admin@bims.com",
                NormalizedEmail = "ADMIN@BIMS.COM",
            };
            user2.PasswordHash = ph.HashPassword(user2, "Ad@123");

            var user3 = new IdentityUser
            {
                Id = "b7f46612-41d2-47ba-af30-f957a680d92a",
                UserName = "ibrahim@bims.com",
                NormalizedUserName = "IBRAHIM@BIMS.COM",
                Email = "ibrahim@bims.com",
                NormalizedEmail = "IBRAHIM@BIMS.COM",
            };
            user3.PasswordHash = ph.HashPassword(user3, "Ibr@56");

            var user4 = new IdentityUser
            {
                Id = "0442b285-375d-48a0-8f47-d6e21bf342c9",
                UserName = "sajib@bims.com",
                NormalizedUserName = "SAJIB@BIMS.COM",
                Email = "sajib@bims.com",
                NormalizedEmail = "SAJIB@BIMS.COM",
            };
            user4.PasswordHash = ph.HashPassword(user4, "Saj@56");

            //Seed User
            builder.Entity<IdentityUser>().HasData(user1, user2, user3, user4);
        }


        //Seed User Role
        public static void SeedUserRole(this ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "c02f71c8-a822-4b3a-900c-5c62478b32f0", RoleId = "70cecf66-f00e-406f-ae29-0feb2183689c" },
                new IdentityUserRole<string> { UserId = "4b9d054d-bcb0-475e-96be-7e07d5ee3b85", RoleId = "f672f1be-450b-4899-b9a5-13a0ff856015" }
                );
        }
    }
}
