using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.MVCUI.Areas.Member.Models.PageVMs.TaskVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class MyTaskController : Controller
    {
        readonly ITaskManager _taskManager;

        public MyTaskController(ITaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        public async Task<IActionResult> Index()
        {
            // Login sistemi tamamlanınca burası Session/User.Identity'den alınacak.
            int userId = 1;

            MyTaskPageVm vm = new MyTaskPageVm();

            vm.Tasks = await _taskManager.GetTasksByUserAsync(userId);
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            TaskDetailPageVm vm = new();

            vm.Task = await _taskManager.GetByIdAsync(id);

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