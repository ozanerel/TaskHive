using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.BogusHandling
{
    public static class UserSeed
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            User user1 = new()
            {
                Id = 1,
                FirstName = "Ahmet",
                LastName = "Yilmaz",
                Email = "ahmet@test.com",
                RoleId = 3,
                AppUserId = 2
            };

            //User user2 = new()
            //{
            //    Id = 2,
            //    FirstName = "Ayse",
            //    LastName = "Demir",
            //    Email = "ayse@test.com",
            //    RoleId = 4,
            //    AppUserId = 2
            //};

            // User user3 = new()
            // {
            //     Id = 3,
            //     FirstName = "Mehmet",
            //     LastName = "Kaya",
            //     Email = "mehmet@test.com",
            //     RoleId = 5,
            //     AppUserId = 2
            // };

            modelBuilder.Entity<User>().HasData(user1);
        }
    }
}
