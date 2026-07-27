using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.RoleVM
{
    public class RoleIndexVm
    {
        public List<Role> Roles { get; set; } = new();
    }
}