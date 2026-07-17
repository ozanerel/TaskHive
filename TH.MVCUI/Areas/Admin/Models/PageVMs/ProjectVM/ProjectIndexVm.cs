using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM
{
    public class ProjectIndexVm
    {
        public List<Project> Projects { get; set; } = new();
    }
}