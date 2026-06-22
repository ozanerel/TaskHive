using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.TaskCommentVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class TaskCommentController : Controller
    {
        readonly ITaskCommentManager _taskCommentManager;
        readonly ITaskManager _taskManager;
        readonly IUserManager _userManager;

        public TaskCommentController
        (
            ITaskCommentManager taskCommentManager,
            ITaskManager taskManager,
            IUserManager userManager
        )
        {
            _taskCommentManager = taskCommentManager;
            _taskManager = taskManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TaskCommentIndexVm vm = new TaskCommentIndexVm();

            vm.Comments = await _taskCommentManager.GetAllAsync();

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            TaskCommentDetailsVm vm = new()
            {
                Comment = comment
            };

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Tasks = await _taskManager.GetAllAsync();
            ViewBag.Users = await _userManager.GetAllAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskCommentCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tasks = await _taskManager.GetAllAsync();
                ViewBag.Users = await _userManager.GetAllAsync();
                return View(vm);
            }

            TH.ENTITIES.Models.TaskComment comment = new()
            {
                Message = vm.Message,
                TaskId = vm.TaskId,
                UserId = vm.UserId,
                IsRead = false
            };

            await _taskCommentManager.CreateAsync(comment);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            ViewBag.Tasks = await _taskManager.GetAllAsync();
            ViewBag.Users = await _userManager.GetAllAsync();

            TaskCommentUpdateVm vm = new()
            {
                Id = comment.Id,
                Message = comment.Message,
                TaskId = comment.TaskId,
                UserId = comment.UserId,
                IsRead = comment.IsRead
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskCommentUpdateVm vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tasks = await _taskManager.GetAllAsync();
                ViewBag.Users = await _userManager.GetAllAsync();

                return View(vm);
            }

            var comment = await _taskCommentManager.GetByIdAsync(vm.Id);

            if (comment == null)
                return NotFound();

            comment.Message = vm.Message;
            comment.TaskId = vm.TaskId;
            comment.UserId = vm.UserId;
            comment.IsRead = vm.IsRead;

            await _taskCommentManager.UpdateAsync(comment);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            await _taskCommentManager.MakePassiveAsync(comment);

            return RedirectToAction(nameof(Index));
        }
    }
}