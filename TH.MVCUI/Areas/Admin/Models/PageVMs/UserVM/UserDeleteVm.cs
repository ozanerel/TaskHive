using TH.ENTITIES.Enums;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.UserVM
{
    public class UserDeleteVm
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        
        public string Email { get; set; }

        public string RoleName { get; set; }
        public int ProjectCount { get; set; }
        public int TaskCount { get; set; }
        public DataStatus Status { get; set; }
    }
}