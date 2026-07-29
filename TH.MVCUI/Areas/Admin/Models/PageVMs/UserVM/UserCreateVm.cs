using System.ComponentModel.DataAnnotations;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.UserVM
{
    public class UserCreateVm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role selection is required.")]
        public int RoleId { get; set; }

        public List<Role> Roles { get; set; } = new();
    }
}