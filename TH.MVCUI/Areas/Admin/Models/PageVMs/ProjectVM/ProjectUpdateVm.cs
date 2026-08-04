using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM
{
    public class ProjectUpdateVm
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        // Seçilen kullanıcılar
        public List<int> UserIds { get; set; } = new();


        // Dropdown/list için tüm kullanıcılar
        public List<User> Users { get; set; } = new();
    }
}
