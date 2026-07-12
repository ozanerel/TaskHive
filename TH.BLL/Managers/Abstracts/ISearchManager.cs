using TH.BLL.DTOs.Search;

namespace TH.BLL.Managers.Abstracts
{
    public interface ISearchManager
    {
        Task<SearchResultDto> SearchAsync(string keyword);
    }
}