using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.UserVM
{
    public class UserIndexVm
    {
        public List<User> Users { get; set; } = new();

        public string Search { get; set; }

        public int? RoleId { get; set; }

        public string Status { get; set; }


        public List<Role> Roles { get; set; } = new();
    }
}