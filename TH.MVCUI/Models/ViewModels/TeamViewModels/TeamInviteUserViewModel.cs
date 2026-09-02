using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Models.ViewModels.TeamViewModels
{
    public class TeamInviteUserViewModel
    {
        [Required]
        public int TeamId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string? TeamName { get; set; }

        public string? UserFullName { get; set; }

        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "UserTag zorunludur")]
        public string UserTag { get; set; }
    }
}