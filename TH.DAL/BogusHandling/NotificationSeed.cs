using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.BogusHandling
{
    public static class NotificationSeed
    {
        public static void SeedNotifications(ModelBuilder modelBuilder)
        {
            Notification notification1 = new()
            {
                Id = 1,
                Title = "New Task Assigned",
                Message = "JWT task assigned to you",
                IsRead = false,
                UserId = 1
            };
            Notification notification2 = new()
            {
                Id = 2,
                Title = "Task Updated",
                Message = "Login page task updated",
                IsRead = false,
                UserId = 2
            };
         
            modelBuilder.Entity<Notification>().HasData(notification1, notification2);
        }
    }
}
