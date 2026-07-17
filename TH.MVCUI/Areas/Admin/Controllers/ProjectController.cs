using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using Microsoft.AspNetCore.Authorization;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM;

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
            ProjectCreateVm vm = new();
            //vm.Project = new Project(); // Initialize the Project property

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectCreateVm vm)
        {
            //if (!ModelState.IsValid)
            //    return View(vm);

            //await _projectManager.CreateAsync(vm.Project);

            //return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid)
                return View(vm);


            Project project = new Project
            {
                ProjectName = vm.ProjectName,
                Description = vm.Description
            };


            await _projectManager.CreateAsync(project);


            return RedirectToAction(nameof(Index));

        }

        // GET
        public async Task<IActionResult> Update(int id)
        {
            var project = await _projectManager.GetByIdAsync(id);

            if (project == null)
                return NotFound();

            //ProjectPageVm vm = new ProjectPageVm
            //{
            //    Project = project
            //};

            ProjectUpdateVm vm = new()
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description
            };

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProjectUpdateVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var project = await _projectManager.GetByIdAsync(vm.Id);

            project.ProjectName = vm.ProjectName;
            project.Description = vm.Description;

            await _projectManager.UpdateAsync(project);

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