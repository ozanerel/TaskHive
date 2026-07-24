namespace TH.MVCUI.Areas.Admin.Models.PageVMs.TaskVM
{
    public class TaskDeleteVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ProjectName { get; set; }

        public string UserName { get; set; }

        public bool IsCompleted { get; set; }
    }
}
