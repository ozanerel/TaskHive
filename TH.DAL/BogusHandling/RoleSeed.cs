using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.BogusHandling
{
    public static class RoleSeed
    {
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            Role role1 = new()
            {
                Id = 1,
                Name = "Admin",
                Description = "System Administrator"
            };

            Role role2 = new()
            {
                Id = 2,
                Name = "Project Manager",
                Description = "Project Manager"
            };

            Role role3 = new()
            {
                Id = 3,
                Name = "Backend Developer",
                Description = "Backend Developer"
            };

            Role role4 = new()
            {
                Id = 4,
                Name = "Frontend Developer",
                Description = "Frontend Developer"
            };

            Role role5 = new()
            {
                Id = 5,
                Name = "Tester",
                Description = "Quality Assurance"
            };
            modelBuilder.Entity<Role>().HasData(role1, role2, role3, role4, role5);
        }
    }
}
