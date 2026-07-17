namespace TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM
{
    public class ProjectDetailsVm
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public List<Task> Tasks { get; set; } = new();
    }
}
