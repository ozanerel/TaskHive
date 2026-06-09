using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.BogusHandling
{
    public static class TaskSeed
    {
        public static void SeedTasks(ModelBuilder modelBuilder)
        {
            ENTITIES.Models.Task task1 = new()
            {
                Id = 1,
                Title = "Create Login Page",
                Description = "Develop login screen",
                Priority = PriorityLevel.Critical,
                IsCompleted = false,
                UserId = 2,
                ProjectId = 1
            };

            ENTITIES.Models.Task task2 = new()
            {
                Id = 2,
                Title = "Implement JWT",
                Description = "Develop authentication infrastructure",
                Priority = PriorityLevel.High,
                IsCompleted = false,
                UserId = 1,
                ProjectId = 1
            };

            ENTITIES.Models.Task task3 = new()
            {
                Id = 3,
                Title = "Prepare Test Cases",
                Description = "Write test scenarios",
                Priority = PriorityLevel.Medium,
                IsCompleted = true,
                UserId = 3,
                ProjectId = 1
            };

            modelBuilder.Entity<ENTITIES.Models.Task>().HasData(task1, task2, task3);
        }
    }
}
