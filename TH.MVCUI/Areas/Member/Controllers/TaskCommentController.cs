using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.TaskCommentVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class TaskCommentController : Controller
    {
        private readonly ITaskCommentManager _taskCommentManager;
        private readonly ITaskManager _taskManager;
        private readonly IUserContext _userContext;

        public TaskCommentController(
            ITaskCommentManager taskCommentManager,
            ITaskManager taskManager,
            IUserContext userContext)
        {
            _taskCommentManager = taskCommentManager;
            _taskManager = taskManager;
            _userContext = userContext;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comments = await _taskCommentManager
                .GetCommentsByUserAsync(user.Id);

            TaskCommentIndexVm vm = new()
            {
                Comments = comments
            };

            return View(vm);
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager
                .GetCommentByUserAsync(id, user.Id);

            if (comment == null)
                return NotFound();

            TaskCommentDetailsVm vm = new()
            {
                Comment = comment
            };

            return View(vm);
        }

        // CREATE GET
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var tasks = await _taskManager
                .GetTasksByUserAsync(user.Id);

            ViewBag.Tasks = tasks;

            return View(new TaskCommentCreateVm());
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            TaskCommentCreateVm vm)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            // Task gerçekten bu kullanıcıya mı ait?
            var task = await _taskManager
                .GetTaskDetailsByUserAsync(
                    vm.TaskId,
                    user.Id);

            if (task == null)
                return Forbid();

            if (!ModelState.IsValid)
            {
                ViewBag.Tasks = await _taskManager
                    .GetTasksByUserAsync(user.Id);

                return View(vm);
            }

            TaskComment comment = new()
            {
                Message = vm.Message,
                TaskId = task.Id,
                UserId = user.Id,
                IsRead = false
            };

            await _taskCommentManager.CreateAsync(comment);

            return RedirectToAction(nameof(Index));
        }

        // EDIT GET
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager
                .GetCommentByUserAsync(id, user.Id);

            if (comment == null)
                return NotFound();

            TaskCommentUpdateVm vm = new()
            {
                Id = comment.Id,
                Message = comment.Message
            };

            return View(vm);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            TaskCommentUpdateVm vm)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager
                .GetCommentByUserAsync(
                    vm.Id,
                    user.Id);

            if (comment == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(vm);

            comment.Message = vm.Message;

            await _taskCommentManager.UpdateAsync(comment);

            return RedirectToAction(nameof(Index));
        }

        // DELETE GET
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager
                .GetCommentByUserAsync(id, user.Id);

            if (comment == null)
                return NotFound();

            TaskCommentDeleteVm vm = new()
            {
                Id = comment.Id,
                Message = comment.Message
            };

            return View(vm);
        }

        // DELETE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(
            TaskCommentDeleteVm vm)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager
                .GetCommentByUserAsync(
                    vm.Id,
                    user.Id);

            if (comment == null)
                return NotFound();

            await _taskCommentManager.MakePassiveAsync(comment);

            return RedirectToAction(nameof(Index));
        }
    }
}