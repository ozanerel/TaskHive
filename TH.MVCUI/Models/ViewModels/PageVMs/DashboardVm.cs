using TH.ENTITIES.Models;

namespace TH.MVCUI.Models.ViewModels.PageVMs
{
    public class DashboardVm
    {

        public int TotalProjects { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int TotalUsers { get; set; }
        public List<Project> RecentProjects { get; set; }
        public List<TH.ENTITIES.Models.Task> RecentTasks { get; set; }

    }
}
