namespace TH.MVCUI.Areas.Member.Models.PageVMs.ProfileVM
{
    public class ProfileVm
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }

        public string? ImageUrl { get; set; }
    }
}