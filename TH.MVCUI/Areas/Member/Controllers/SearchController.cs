using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.MVCUI.Models.ViewModels;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class SearchController : Controller
    {
        private readonly ISearchManager _searchManager;
        private readonly IUserContext _userContext;

        public SearchController(
            ISearchManager searchManager,
            IUserContext userContext)
        {
            _searchManager = searchManager;
            _userContext = userContext;
        }

        public async Task<IActionResult> Index(string keyword)
        {
            SearchVm vm = new();

            vm.Keyword = keyword;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var user = await _userContext.GetCurrentUserAsync();

                if (user == null)
                    return NotFound();

                var result = await _searchManager.SearchAsync(
                    keyword,
                    user.Id,
                    false);

                vm.Projects = result.Projects;
                vm.Tasks = result.Tasks;
                vm.Users = result.Users;
            }

            return View(vm);
        }
    }
}