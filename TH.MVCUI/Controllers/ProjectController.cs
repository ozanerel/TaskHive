using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Controllers
{
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
            var projects = await _projectManager.GetAllAsync();

            return View(projects);
        }

        // Proje Detayı
        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectManager.GetProjectDetailsAsync(id);

            if (project == null)
                return NotFound();

            return View(project);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
                return View(project);

            await _projectManager.CreateAsync(project);

            return RedirectToAction(nameof(Index));
        }

        // GET
        public async Task<IActionResult> Update(int id)
        {
            var project = await _projectManager.GetByIdAsync(id);

            if (project == null)
                return NotFound();

            return View(project);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Project project)
        {
            if (!ModelState.IsValid)
                return View(project);

            await _projectManager.UpdateAsync(project);

            return RedirectToAction(nameof(Index));
        }

        // GET
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectManager.GetByIdAsync(id);

            if (project == null)
                return NotFound();

            return View(project);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Project project)
        {
            await _projectManager.MakePassiveAsync(project);

            return RedirectToAction(nameof(Index));
        }
    }
}