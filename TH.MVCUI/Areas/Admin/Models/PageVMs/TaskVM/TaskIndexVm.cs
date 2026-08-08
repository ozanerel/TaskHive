using TH.ENTITIES.Enums;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.TaskVM
{
    public class TaskIndexVm
    {
        public List<ENTITIES.Models.Task> Tasks { get; set; }
            = new();

        public string Search { get; set; }

        public PriorityLevel? Priority { get; set; }

        public bool? IsCompleted { get; set; }
    }
}
