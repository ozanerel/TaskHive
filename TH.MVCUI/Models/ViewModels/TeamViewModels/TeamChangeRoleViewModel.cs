using System.ComponentModel.DataAnnotations;
using TH.ENTITIES.Enums;

namespace TH.MVCUI.Models.ViewModels.TeamViewModels
{
    public class TeamChangeRoleViewModel
    {
        public int TeamId { get; set; }

        public int UserId { get; set; }

        public TeamRole TeamRole { get; set; }
    }
}