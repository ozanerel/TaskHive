using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.UserVM
{
    public class UserIndexVm
    {
        public List<User> Users { get; set; } = new();
    }
}