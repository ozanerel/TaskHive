using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs
{
    public class UserPageVm
    {
        public User User { get; set; }

        public List<User> Users { get; set; }

        public List<Role> Roles { get; set; }

        public List<Project> Projects { get; set; }

        public List<ENTITIES.Models.Task> Tasks { get; set; }
    }
}
