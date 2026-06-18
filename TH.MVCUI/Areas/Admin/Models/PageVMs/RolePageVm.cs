using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs
{
    public class RolePageVm
    {
        public Role Role { get; set; }

        public List<Role> Roles { get; set; }

        public List<User> Users { get; set; }
    }
}
