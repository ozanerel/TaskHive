using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.BogusHandling
{
    public static class TaskCommentSeed
    {
        public static void SeedTaskComments(ModelBuilder modelBuilder)
        {
            TaskComment comment1 = new()
            {
                Id = 1,
                Message = "Login page completed",
                TaskId = 1,
                UserId = 2
            };
            TaskComment comment2 = new()
            {
                Id = 2,
                Message = "JWT implementation started",
                TaskId = 2,
                UserId = 1
            };
           
            modelBuilder.Entity<TaskComment>().HasData(comment1, comment2);
        }
    }
}
