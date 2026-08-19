using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.BogusHandling
{
    public static class ProjectSeed
    {
        public static void SeedProjects(ModelBuilder modelBuilder)
        {
            Project project1 = new()
            {
                Id = 1,
                ProjectName = "TaskHive",
                Description = "Project Management System",
                TeamId = 1
            };
            //Project project2 = new()
            //{
            //    Id = 2,
            //    ProjectName = "IKYS",
            //    Description = "Human Resources Management System"
            //};
          
            modelBuilder.Entity<Project>().HasData(project1);
        }
    }
}
