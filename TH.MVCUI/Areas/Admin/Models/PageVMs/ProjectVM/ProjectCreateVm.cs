using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM
{
    public class ProjectCreateVm
    {
        public string ProjectName { get; set; }

        public string Description { get; set; }

        public int TeamId { get; set; }

        public List<int> UserIds { get; set; }
            = new();

        public List<User> Users { get; set; }
            = new();
    }
}