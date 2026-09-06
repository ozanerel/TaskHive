using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Enums;
using TH.MVCUI.Areas.Member.Models.PageVMs.MyProjectVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class MyProjectController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly IUserContext _userContext;

        public MyProjectController(
            IProjectManager projectManager,
            IUserContext userContext)
        {
            _projectManager = projectManager;
            _userContext = userContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var projects = await _projectManager.GetProjectsByUserAsync(user.Id);

            List<MyProjectListVm> vm = projects.Select(x => new MyProjectListVm
            {
                Id = x.Id,
                ProjectName = x.ProjectName,
                Description = x.Description,
                UserCount = x.Users.Count,
                TaskCount = x.Tasks.Count,
                Status = x.Status
            }).ToList();

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var project = await _projectManager.GetProjectDetailsByUserAsync(id,user.Id);

            if (project == null)
                return NotFound();

            //if (project.Status == DataStatus.Deleted)
            //    return NotFound();

            //if (!project.Users.Any(x => x.Id == user.Id))
            //    return Forbid();

            MyProjectDetailsVm vm = new MyProjectDetailsVm
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                Users = project.Users.ToList(),
                Tasks = project.Tasks.ToList()
            };

            return View(vm);
        }
    }
}