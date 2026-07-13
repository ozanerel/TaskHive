using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.MVCUI.Models.ViewModels;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class SearchController : Controller
    {
        private readonly ISearchManager _searchManager;

        public SearchController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        public async Task<IActionResult> Index(string keyword)
        {
            SearchVm vm = new();

            vm.Keyword = keyword;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var result = await _searchManager.SearchAsync(keyword);

                vm.Projects = result.Projects;

                vm.Tasks = result.Tasks;

                vm.Users = result.Users;
            }

            return View(vm);
        }
    }
}