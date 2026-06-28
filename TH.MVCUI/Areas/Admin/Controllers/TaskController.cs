using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Managers.Concretes;
using TH.MVCUI.Areas.Admin.Models.PageVMs;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

            TaskPageVm vm = new()
            {
                Tasks = tasks
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            TaskPageVm vm = new()
            {
                Task = task
            };

            return View(vm);
        }

        public IActionResult Create()
        {
            TaskPageVm vm = new();

            vm.Task = new ENTITIES.Models.Task();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskPageVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _taskManager.CreateAsync(vm.Task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            TaskPageVm vm = new()
            {
                Task = task
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskPageVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await _taskManager.UpdateAsync(vm.Task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            TaskPageVm vm = new()
            {
                Task = task
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TaskPageVm vm)
        {
            await _taskManager.MakePassiveAsync(vm.Task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CompleteTask(int id)
        {
            await _taskManager.CompleteTaskAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
