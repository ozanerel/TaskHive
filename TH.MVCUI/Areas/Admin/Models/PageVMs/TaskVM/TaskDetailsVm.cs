using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.TaskVM
{
    public class TaskDetailsVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public PriorityLevel Priority { get; set; }

        public bool IsCompleted { get; set; }

        public string ProjectName { get; set; }

        public string UserName { get; set; }

        public List<TaskComment> Comments { get; set; }
            = new();
    }
}
