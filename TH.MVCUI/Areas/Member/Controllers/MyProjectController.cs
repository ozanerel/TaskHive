using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.MyProjectVM;


namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class MyProjectController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly IUserManager _userManager;
        private readonly IUserContext _userContext;

        public MyProjectController(IProjectManager projectManager,
                                   IUserManager userManager,IUserContext userContext)
        {
            _projectManager = projectManager;
            _userManager = userManager;
            _userContext = userContext;
        }

        // MEMBER'A AİT PROJELER
        public async Task<IActionResult> Index()
        {
            
            //int userId = 1;

            //var user = await _userManager.GetByIdAsync(userId);

            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var projects = user.Projects;

            List<MyProjectListVm> vm = projects.Select(x => new MyProjectListVm
            {
                Id = x.Id,
                ProjectName = x.ProjectName,
                Description = x.Description,
                UserCount = x.Users.Count,
                TaskCount = x.Tasks.Count
            }).ToList();

            return View(vm);
        }

        // PROJE DETAYI
        public async Task<IActionResult> Details(int id)
        {
            Project project = await _projectManager.GetProjectDetailsAsync(id);

            if (project == null)
                return NotFound();

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