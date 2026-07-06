using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Member.Models.PageVMs.TaskCommentVM
{
    public class TaskCommentPageVm
    {
        public TaskComment TaskComment { get; set; }

        public List<TaskComment> TaskComments { get; set; }

        public List<ENTITIES.Models.Task> Tasks { get; set; }

        public List<User> Users { get; set; }
    }
}
