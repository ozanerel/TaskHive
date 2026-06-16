using TH.ENTITIES.Models;

namespace TH.MVCUI.Models.PageVMs
{
    public class ProjectPageVm
    {
        public Project Project { get; set; }

        public List<Project> Projects { get; set; }

        public List<User> Users { get; set; }

        public List<TH.ENTITIES.Models.Task> Tasks { get; set; }
    }
}