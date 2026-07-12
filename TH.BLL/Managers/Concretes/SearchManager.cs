using TH.BLL.DTOs.Search;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;

namespace TH.BLL.Managers.Concretes
{
    public class SearchManager : ISearchManager
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public SearchManager(
            IProjectRepository projectRepository,
            ITaskRepository taskRepository,
            IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public async Task<SearchResultDto> SearchAsync(string keyword)
        {
            SearchResultDto dto = new();

            if (string.IsNullOrWhiteSpace(keyword))
                return dto;

            keyword = keyword.Trim();

            dto.Projects = await _projectRepository.SearchProjectsAsync(keyword);

            dto.Tasks = await _taskRepository.SearchTasksAsync(keyword);

            dto.Users = await _userRepository.SearchUsersAsync(keyword);

            return dto;
        }
    }
}