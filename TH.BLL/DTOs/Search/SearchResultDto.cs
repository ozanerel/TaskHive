using TH.ENTITIES.Models;

namespace TH.BLL.DTOs.Search
{
    public class SearchResultDto
    {
        public List<Project> Projects { get; set; } = new();

        public List<TH.ENTITIES.Models.Task> Tasks { get; set; } = new();

        public List<User> Users { get; set; } = new();
    }
}