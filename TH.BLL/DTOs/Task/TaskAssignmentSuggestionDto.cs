using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH.BLL.DTOs.Task
{

    //Bu sistemin amacı, yeni bir görev atanırken ekip üyelerinin mevcut görev yüklerini dikkate alarak görev ataması için yardımcı olmaktır.
    public class TaskAssignmentSuggestionDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string RoleName { get; set; }

        public int TotalTasks { get; set; }

        public int PendingTasks { get; set; }

        public int OverdueTasks { get; set; }

        public double CompletionRate { get; set; }

        public int WorkloadScore { get; set; }

        public int? RoleId { get; set; }
    }
}
