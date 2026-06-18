using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Managers.Concretes;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskManager _taskManager;

        public TaskController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskManager.GetAllAsync();
            return View(tasks);
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            return View(task);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ENTITIES.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                await _taskManager.CreateAsync(task);
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ENTITIES.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                await _taskManager.UpdateAsync(task);
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            await _taskManager.MakePassiveAsync(task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CompleteTask(int id)
        {
            await _taskManager.CompleteTaskAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
