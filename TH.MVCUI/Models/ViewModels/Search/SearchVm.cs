using TH.ENTITIES.Models;

namespace TH.MVCUI.Models.ViewModels
{
    public class SearchVm
    {
        public string Keyword { get; set; }

        public List<Project> Projects { get; set; } = new();

        public List<TH.ENTITIES.Models.Task> Tasks { get; set; } = new();

        public List<User> Users { get; set; } = new();
    }
}