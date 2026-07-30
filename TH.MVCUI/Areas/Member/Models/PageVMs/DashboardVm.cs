using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Member.Models.PageVMs
{
    public class DashboardVm
    {

        public int TotalProjects { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int TotalUsers { get; set; }
        public List<Project> RecentProjects { get; set; }
        public List<ENTITIES.Models.Task> RecentTasks { get; set; }
        public int UnreadNotificationCount { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Notification> RecentNotifications { get; set; } = new();
        public List<User> RecentUsers { get; set; } = new();

    }
}
