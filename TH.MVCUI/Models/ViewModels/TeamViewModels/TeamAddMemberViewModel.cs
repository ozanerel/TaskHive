using System.ComponentModel.DataAnnotations;

namespace TH.MVCUI.Models.ViewModels.TeamViewModels
{
    public class TeamAddMemberViewModel
    {
        public int TeamId { get; set; }

        public string? TeamName { get; set; }

        [Required(ErrorMessage = "Kullanıcı seçmelisiniz.")]
        public int UserId { get; set; }

        public List<TeamUserSelectViewModel> Users { get; set; }
            = new();
    }

    public class TeamUserSelectViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}