using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs
{
    public class TaskPageVm
    {
        public ENTITIES.Models.Task Task { get; set; }

        public List<ENTITIES.Models.Task> Tasks { get; set; }

        public List<User> Users { get; set; }

        public List<Project> Projects { get; set; }

        public List<TaskComment> Comments { get; set; }
    }
}
