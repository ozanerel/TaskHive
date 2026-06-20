using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Areas.Member.ViewModels.ProfileVM
{
    public class EditProfileVm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}