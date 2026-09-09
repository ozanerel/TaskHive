using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Enums;
using TH.MVCUI.Areas.Admin.Models.PageVMs.TaskCommentVM;
using TH.MVCUI.Areas.Member.Models.PageVMs.TaskCommentVM;
using TaskCommentDeleteVm = TH.MVCUI.Areas.Admin.Models.PageVMs.TaskCommentVM.TaskCommentDeleteVm;
using TaskCommentDetailsVm = TH.MVCUI.Areas.Admin.Models.PageVMs.TaskCommentVM.TaskCommentDetailsVm;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TaskCommentController : Controller
    {
        private readonly ITaskCommentManager _taskCommentManager;
        private readonly ITaskManager _taskManager;
        private readonly ITeamMemberManager _teamMemberManager;
        private readonly IUserContext _userContext;

        public TaskCommentController(
            ITaskCommentManager taskCommentManager,
            ITaskManager taskManager,
            ITeamMemberManager teamMemberManager,
            IUserContext userContext)
        {
            _taskCommentManager = taskCommentManager;
            _taskManager = taskManager;
            _teamMemberManager = teamMemberManager;
            _userContext = userContext;
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userContext
                .GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager
                .GetCommentDetailsAsync(id);

            if (comment == null)
                return NotFound();

            if (comment.Task == null)
                return NotFound();

            if (comment.Task.Project == null)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                comment.Task.Project.TeamId,
                user.Id);

            if (!isTeamAdmin)
                return Forbid();

            TaskCommentDetailsVm vm = new()
            {
                Comment = comment
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userContext
                .GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager
                .GetCommentDetailsAsync(id);

            if (comment == null)
                return NotFound();

            if (comment.Task == null)
                return NotFound();

            if (comment.Task.Project == null)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                comment.Task.Project.TeamId,
                user.Id);

            if (!isTeamAdmin)
                return Forbid();

            TaskCommentDeleteVm vm = new()
            {
                Id = comment.Id,
                TaskId = comment.TaskId,
                Message = comment.Message
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(
            TaskCommentDeleteVm vm)
        {
            var user = await _userContext
                .GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var comment = await _taskCommentManager
                .GetCommentDetailsAsync(vm.Id);

            if (comment == null)
                return NotFound();

            if (comment.Task == null)
                return NotFound();

            if (comment.Task.Project == null)
                return NotFound();

            var isTeamAdmin = await IsTeamAdminAsync(
                comment.Task.Project.TeamId,
                user.Id);

            if (!isTeamAdmin)
                return Forbid();

            await _taskCommentManager
                .DeleteCommentByTeamAdminAsync(
                    comment.Id,
                    user.Id);

            return RedirectToAction(
                "Details",
                "Task",
                new
                {
                    id = comment.TaskId
                });
        }

        private async Task<bool> IsTeamAdminAsync(
            int teamId,
            int userId)
        {
            var teamMember = await _teamMemberManager
                .GetTeamMemberAsync(
                    teamId,
                    userId);

            return teamMember != null &&
                   teamMember.TeamRole == TeamRole.Admin &&
                   teamMember.Status != DataStatus.Deleted;
        }
    }
}