using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.TaskVM
{
    public class TaskUpdateVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? DueDate { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public int? RequiredRoleId { get; set; }

        public bool IsCompleted { get; set; }

        public List<User> Users { get; set; } = new();

        public List<Project> Projects { get; set; } = new();

        public List<Role> Roles { get; set; } = new();
    }
}
