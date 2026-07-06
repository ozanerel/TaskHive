using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.TaskCommentVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class TaskCommentController : Controller
    {
        private readonly ITaskCommentManager _taskCommentManager;
        private readonly ITaskManager _taskManager;
        private readonly IUserManager _userManager;

        public TaskCommentController(
            ITaskCommentManager taskCommentManager,
            ITaskManager taskManager,
            IUserManager userManager)
        {
            _taskCommentManager = taskCommentManager;
            _taskManager = taskManager;
            _userManager = userManager;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            TaskCommentIndexVm vm = new()
            {
                Comments = await _taskCommentManager.GetAllAsync()
            };

            return View(vm);
        }

        // DETAILS
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

        // CREATE
        public async Task<IActionResult> Create()
        {
            ViewBag.Tasks = await _taskManager.GetAllAsync();
            ViewBag.Users = await _userManager.GetAllAsync();

            return View(new TaskCommentCreateVm());
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

            TaskComment comment = new()
            {
                Message = vm.Message,
                TaskId = vm.TaskId,
                UserId = vm.UserId,
                IsRead = false
            };

            await _taskCommentManager.CreateAsync(comment);

            return RedirectToAction(nameof(Index));
        }

        // EDIT
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

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            TaskCommentDeleteVm vm = new()
            {
                Comment = comment
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TaskCommentDeleteVm vm)
        {
            var comment = await _taskCommentManager.GetByIdAsync(vm.Comment.Id);

            if (comment == null)
                return NotFound();

            await _taskCommentManager.MakePassiveAsync(comment);

            return RedirectToAction(nameof(Index));
        }
    }
}