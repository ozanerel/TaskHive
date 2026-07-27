using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.UserVM
{
    public class UserDetailsVm
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }

        public List<Project> Projects { get; set; } = new();

        public List<ENTITIES.Models.Task> Tasks { get; set; } = new();

        public int ProjectCount => Projects.Count;

        public int TaskCount => Tasks.Count;

        public DataStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}