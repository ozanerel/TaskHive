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
                RoleId = 3
            };

             User user2 = new()
             {
                 Id = 2,
                 FirstName = "Ayse",
                 LastName = "Demir",
                 Email = "ayse@test.com",
                 RoleId = 4
             };

              User user3 = new()
              {
                  Id = 3,
                  FirstName = "Mehmet",
                  LastName = "Kaya",
                  Email = "mehmet@test.com",
                  RoleId = 5
              };

            modelBuilder.Entity<User>().HasData(user1, user2, user3);
        }
    }
}
