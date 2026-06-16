using TH.ENTITIES.Models;

namespace TH.MVCUI.Models.PageVMs
{
    public class TaskPageVm
    {
        public TH.ENTITIES.Models.Task Task { get; set; }

        public List<TH.ENTITIES.Models.Task> Tasks { get; set; }

        public List<User> Users { get; set; }

        public List<Project> Projects { get; set; }

        public List<TaskComment> Comments { get; set; }
    }
}
