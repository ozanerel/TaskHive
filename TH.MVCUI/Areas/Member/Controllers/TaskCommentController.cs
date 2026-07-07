using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
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
        private readonly IUserContext _userContext;
        public TaskCommentController(
            ITaskCommentManager taskCommentManager,
            ITaskManager taskManager,
            IUserManager userManager,
            IUserContext userContext)
        {
            _taskCommentManager = taskCommentManager;
            _taskManager = taskManager;
            _userManager = userManager;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var user = await _userContext.GetCurrentUserAsync();

            var comments = (await _taskCommentManager.GetAllAsync())
                .Where(x => x.UserId == user.Id)
                .ToList();

            TaskCommentIndexVm vm = new()
            {
                Comments = comments
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
            var user = await _userContext.GetCurrentUserAsync();

            ViewBag.Tasks = user.Tasks;
            ViewBag.Users = new List<User> { user };

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

            var user = await _userContext.GetCurrentUserAsync();

            TaskComment comment = new()
            {
                Message = vm.Message,
                TaskId = vm.TaskId,
                UserId = user.Id,
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

            var user = await _userContext.GetCurrentUserAsync();

            ViewBag.Tasks = user.Tasks;
            ViewBag.Users = new List<User> { user };

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
            var user = await _userContext.GetCurrentUserAsync();

            if (comment == null)
                return NotFound();

            comment.Message = vm.Message;
            comment.TaskId = vm.TaskId;
            comment.UserId = user.Id;
            comment.IsRead = vm.IsRead;

            await _taskCommentManager.UpdateAsync(comment);

            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _taskCommentManager.GetByIdAsync(id);

            var user = await _userContext.GetCurrentUserAsync();

            if (comment.UserId != user.Id)
                return Forbid();

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