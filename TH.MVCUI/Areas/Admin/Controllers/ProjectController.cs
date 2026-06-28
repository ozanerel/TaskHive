using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.MVCUI.Areas.Admin.Models.PageVMs;
using Microsoft.AspNetCore.Authorization;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectManager _projectManager;

        public ProjectController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        // Proje Listesi
        public async Task<IActionResult> Index()
        {
            var projects = await _projectManager.GetProjectsWithTasksAsync();

            ProjectPageVm vm = new()
            {
                Projects = projects
            };

            return View(vm);
        }

        // Proje Detayı
        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectManager.GetProjectDetailsAsync(id);

            if (project == null)
                return NotFound();

            ProjectPageVm vm = new ProjectPageVm
            {
                Project = project
            };

            return View(vm);
        }

        // GET
        public IActionResult Create()
        {
            ProjectPageVm vm = new();
            vm.Project = new Project(); // Initialize the Project property

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectPageVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _projectManager.CreateAsync(vm.Project);

            return RedirectToAction(nameof(Index));
        }

        // GET
        public async Task<IActionResult> Update(int id)
        {
            var project = await _projectManager.GetByIdAsync(id);

            if (project == null)
                return NotFound();

            ProjectPageVm vm = new ProjectPageVm
            {
                Project = project
            };

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProjectPageVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _projectManager.UpdateAsync(vm.Project);

            return RedirectToAction(nameof(Index));
        }

        // GET
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectManager.GetByIdAsync(id);

            if (project == null)
                return NotFound();

            ProjectPageVm vm = new ProjectPageVm
            {
                Project = project
            };

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProjectPageVm vm)
        {
            await _projectManager.MakePassiveAsync(vm.Project);

            return RedirectToAction(nameof(Index));
        }
    }
}