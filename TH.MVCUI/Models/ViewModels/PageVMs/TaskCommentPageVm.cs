using TH.ENTITIES.Models;

namespace TH.MVCUI.Models.ViewModels.PageVMs
{
    public class TaskCommentPageVm
    {
        public TaskComment TaskComment { get; set; }

        public List<TaskComment> TaskComments { get; set; }

        public List<TH.ENTITIES.Models.Task> Tasks { get; set; }

        public List<User> Users { get; set; }
    }
}
