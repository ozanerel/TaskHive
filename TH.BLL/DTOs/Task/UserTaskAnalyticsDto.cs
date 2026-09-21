using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.BLL.DTOs.Task
{
    public class UserTaskAnalyticsDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int TotalTasks { get; set; }

        public int CompletedTasks { get; set; }

        public int PendingTasks { get; set; }

        public int OverdueTasks { get; set; }

        public double CompletionRate { get; set; }
    }
}
