using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.TaskCommentVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
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

            comments = comments
                .Where(x => x.Status != TH.ENTITIES.Enums.DataStatus.Deleted)
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
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            if (comment.UserId != user.Id)
                return Forbid();

            if (comment.Status == TH.ENTITIES.Enums.DataStatus.Deleted)
                return NotFound();

            TaskCommentDetailsVm vm = new()
            {
                Comment = comment
            };

            return View(vm);
        }

        // CREATE
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            ViewBag.Tasks = user.Tasks
                .Where(x => x.Status != TH.ENTITIES.Enums.DataStatus.Deleted)
                .ToList();

            return View(new TaskCommentCreateVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskCommentCreateVm vm)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                ViewBag.Tasks = user.Tasks
                    .Where(x => x.Status != TH.ENTITIES.Enums.DataStatus.Deleted)
                    .ToList();

                return View(vm);
            }

            // Task gerçekten bu Member'a atanmış mı?
            var task = user.Tasks
                .FirstOrDefault(x =>
                    x.Id == vm.TaskId &&
                    x.Status != TH.ENTITIES.Enums.DataStatus.Deleted);

            if (task == null)
                return Forbid();

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

        // EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            // Sadece yorum sahibi düzenleyebilir
            if (comment.UserId != user.Id)
                return Forbid();

            if (comment.Status == TH.ENTITIES.Enums.DataStatus.Deleted)
                return NotFound();

            TaskCommentUpdateVm vm = new()
            {
                Id = comment.Id,
                Message = comment.Message,
                //TaskId = comment.TaskId
            };

            return View(vm);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskCommentUpdateVm vm)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            if (!ModelState.IsValid)
                return View(vm);

            var comment = await _taskCommentManager.GetByIdAsync(vm.Id);

            if (comment == null)
                return NotFound();

            // Sadece yorum sahibi düzenleyebilir
            if (comment.UserId != user.Id)
                return Forbid();

            if (comment.Status == TH.ENTITIES.Enums.DataStatus.Deleted)
                return NotFound();

            // TaskId formdan değiştirilmesine izin vermiyoruz.
            comment.Message = vm.Message;

            await _taskCommentManager.UpdateAsync(comment);

            return RedirectToAction(nameof(Index));
        }

        // DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            // Sadece yorum sahibi silebilir
            if (comment.UserId != user.Id)
                return Forbid();

            if (comment.Status == TH.ENTITIES.Enums.DataStatus.Deleted)
                return NotFound();

            TaskCommentDeleteVm vm = new()
            {
                Comment = comment
            };

            return View(vm);
        }

        // DELETE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TaskCommentDeleteVm vm)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager.GetByIdAsync(vm.Comment.Id);

            if (comment == null)
                return NotFound();

            // Sadece yorum sahibi silebilir
            if (comment.UserId != user.Id)
                return Forbid();

            if (comment.Status == TH.ENTITIES.Enums.DataStatus.Deleted)
                return NotFound();

            await _taskCommentManager.MakePassiveAsync(comment);

            return RedirectToAction(nameof(Index));
        }
    }
}

//Artık Member'ın yapamayacağı işlemler : 

//UserId değiştiremez
//IsRead değiştiremez
//Başka task'a yorum taşıyamaz
//Başkasının yorumunu düzenleyemez
//Başkasının yorumunu silemez
//Başka Member'ın task'ına yorum yazamaz