using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.RoleVM
{
    public class RoleDetailsVm
    {
        public int Id { get; set; }

        public string RoleName { get; set; }
        public string Description { get; set; }

        public List<User> Users { get; set; } = new();

        public int UserCount => Users.Count;

        public DataStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}