using TH.ENTITIES.Enums;

namespace TH.MVCUI.Models.ViewModels.TeamViewModels
{
    public class TeamInvitationViewModel
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public int InvitedByUserId { get; set; }

        public string InvitedByUserName { get; set; }

        public DateTime CreatedDate { get; set; }

        public InvitationStatus InvitationStatus { get; set; }
    }
}