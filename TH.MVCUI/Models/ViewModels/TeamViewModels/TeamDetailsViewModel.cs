using TH.ENTITIES.Enums;

namespace TH.MVCUI.Models.ViewModels.TeamViewModels
{
    public class TeamDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<TeamMemberViewModel> Members { get; set; }

        public List<TeamProjectViewModel> Projects { get; set; }

        public bool IsAdmin { get; set; }

        public int CurrentUserId { get; set; }
    }

    public class TeamMemberViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }

        public TeamRole TeamRole { get; set; }
    }

    public class TeamProjectViewModel
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public int TaskCount { get; set; }
    }
}