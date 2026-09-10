using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.TaskCommentVM
{
    public class TaskCommentIndexVm
    {
        public List<TaskComment> Comments { get; set; } = new();
    }
}
