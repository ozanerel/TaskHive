using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM
{
    public class ProjectPageVm
    {
        public Project Project { get; set; }

        public List<Project> Projects { get; set; }

        public List<User> Users { get; set; }

        public List<ENTITIES.Models.Task> Tasks { get; set; }
    }
}