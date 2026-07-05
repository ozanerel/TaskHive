using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.MVCUI.Areas.Member.Models.PageVMs.TaskVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class MyTaskController : Controller
    {
        private readonly ITaskManager _taskManager;

        public MyTaskController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        public async Task<IActionResult> Index()
        {
            int userId = 1;

            MyTaskPageVm vm = new()
            {
                Tasks = await _taskManager.GetTasksByUserAsync(userId)
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            TaskDetailPageVm vm = new()
            {
                Task = await _taskManager.GetByIdAsync(id)
            };

            if (vm.Task == null)
                return NotFound();

            return View(vm);
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
        public async Task<IActionResult> Edit(TH.ENTITIES.Models.Task task)
        {
            if (!ModelState.IsValid)
                return View(task);

            await _taskManager.UpdateAsync(task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Complete(int id)
        {
            await _taskManager.CompleteTaskAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}