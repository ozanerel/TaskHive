using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.BLL.DTOs.Task;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.TaskVM
{
    public class TaskCreateVm
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public List<User> Users { get; set; } = new();

        public List<Project> Projects { get; set; } = new();

        public List<TaskAssignmentSuggestionDto> AssignmentSuggestions { get; set; } = new();
    }
}
