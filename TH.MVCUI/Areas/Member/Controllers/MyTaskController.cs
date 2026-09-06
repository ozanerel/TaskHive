using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.MVCUI.Areas.Member.Models.PageVMs.TaskVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class MyTaskController : Controller
    {
        private readonly ITaskManager _taskManager;
        private readonly IUserContext _userContext;

        public MyTaskController(ITaskManager taskManager,IUserContext userContext)
        {
            _taskManager = taskManager;
            _userContext = userContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            MyTaskPageVm vm = new()
            {
                Tasks = await _taskManager.GetTasksByUserAsync(user.Id)
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var task = await _taskManager.GetTaskDetailsByUserAsync(id,user.Id);

            if (task == null)
                return NotFound();

            //if (task.UserId != user.Id)
            //    return Forbid();

            TaskDetailPageVm vm = new()
            {
                Task = task
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var task = await _taskManager.GetTaskDetailsByUserAsync(id, user.Id);

            if (task == null)
                return NotFound();

            MyTaskUpdateVm vm = new()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MyTaskUpdateVm vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var task = await _taskManager.GetTaskDetailsByUserAsync(vm.Id,user.Id);

            if (task == null)
                return NotFound();

            //if (task.UserId != user.Id)
            //    return Forbid();

            //if (task.Status == TH.ENTITIES.Enums.DataStatus.Deleted)
            //    return Forbid();

            task.Title = vm.Title;
            task.Description = vm.Description;
            task.Priority = vm.Priority;

            await _taskManager.UpdateAsync(task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Complete(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            if (task.UserId != user.Id)
                return Forbid();

            if (task.Status == TH.ENTITIES.Enums.DataStatus.Deleted)
                return Forbid();

            if (task.IsCompleted)
                return RedirectToAction(nameof(Index));

            await _taskManager.CompleteTaskAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}