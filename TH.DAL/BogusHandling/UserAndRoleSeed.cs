using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TH.ENTITIES.Models;

namespace TH.DAL.BogusHandling
{
    public static class UserAndRoleSeed
    {
        public static void SeedUsersAndRoles(ModelBuilder modelBuilder)
        {
            IdentityRole<int> appRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(appRole);

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            AppUser appUser = new()
            {
                Id = 1,
                UserName = "admin",
                Email = "admin@th.com",
                NormalizedEmail = "ADMIN@TH.COM",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Admin1234"),
            };

            modelBuilder.Entity<AppUser>().HasData(appUser);

            IdentityUserRole<int> appUserRole = new()
            {
                RoleId = 1,
                UserId = 1,
            };

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(appUserRole);



            IdentityRole<int> memberRole = new()
            {
                Id = 2,
                Name = "Member",
                NormalizedName = "MEMBER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(memberRole);
            PasswordHasher<AppUser> passwordHasher2 = new PasswordHasher<AppUser>();

            AppUser appUser2 = new()
            {
                Id = 2,
                UserName = "ozan",
                Email = "ozan@th.com",
                NormalizedEmail = "OZAN@TH.COM",
                NormalizedUserName = "OZAN",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Ozan1234"),
            };

            modelBuilder.Entity<AppUser>().HasData(appUser2);

            IdentityUserRole<int> appUserRole2 = new()
            {
                RoleId = 2,
                UserId = 2,
            };

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(appUserRole2);
        }
    }
}
