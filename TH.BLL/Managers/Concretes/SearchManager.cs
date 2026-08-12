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

        public async Task<SearchResultDto> SearchAsync(
            string keyword,
            int? userId = null,
            bool isAdmin = false)
        {
            SearchResultDto dto = new();

            if (string.IsNullOrWhiteSpace(keyword))
                return dto;

            keyword = keyword.Trim();

            if (isAdmin)
            {
                dto.Projects =
                    await _projectRepository.SearchProjectsAsync(keyword);

                dto.Tasks =
                    await _taskRepository.SearchTasksAsync(keyword);

                dto.Users =
                    await _userRepository.SearchUsersAsync(keyword);
            }
            else if (userId.HasValue)
            {
                dto.Projects =
                    await _projectRepository
                        .SearchProjectsByUserAsync(
                            keyword,
                            userId.Value);

                dto.Tasks =
                    await _taskRepository
                        .SearchTasksByUserAsync(
                            keyword,
                            userId.Value);

                // Member kullanıcı aramasında sadece aktif kullanıcıları göstereceğiz.
                dto.Users =
                    await _userRepository.SearchUsersAsync(keyword);
            }

            return dto;
        }
    }
}