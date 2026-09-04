using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM
{
    public class ProjectDetailsVm
    {
        //public Project Project { get; set; }
        //public int Id { get; set; }

        //public string ProjectName { get; set; }

        //public string Description { get; set; }

        //public List<Task> Tasks { get; set; } = new();


        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public List<TH.ENTITIES.Models.Task> Tasks { get; set; } = new();

        public List<User> Users { get; set; } = new();

        public DateTime CreatedDate { get; set; }

        public DataStatus Status { get; set; }

        public int TaskCount => Tasks.Count;

        public int MemberCount => Users.Count;

    }
}
