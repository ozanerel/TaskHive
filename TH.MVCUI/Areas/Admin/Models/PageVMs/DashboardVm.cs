using TH.ENTITIES.Models;
using TH.BLL.DTOs.Task;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs
{
    public class DashboardVm
    {

        public int TotalProjects { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int TotalUsers { get; set; }
        public List<Project> RecentProjects { get; set; }
        public List<ENTITIES.Models.Task> RecentTasks { get; set; }
        public List<Notification> RecentNotifications { get; set; } = new();
        public int UnreadNotificationCount { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<User> RecentUsers { get; set; }
        
        //TaskAnalyticsDto içerisinde double
        public double CompletionRate { get; set; }
        public int PendingTasks { get; set; }
        public int InProgressTasks { get; set; }
        public int OverdueTasks { get; set; }
        public List<ProjectTaskAnalyticsDto> ProjectTaskAnalytics { get; set; } = new();
        public List<UserTaskAnalyticsDto> UserTaskAnalytics { get; set; } = new();

    }
}
