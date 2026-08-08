using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Managers.Concretes;
using TH.ENTITIES.Enums;
using TH.MVCUI.Areas.Admin.Models.PageVMs;
using TH.MVCUI.Areas.Admin.Models.PageVMs.TaskVM;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskManager _taskManager;
        private readonly IUserManager _userManager;
        private readonly IProjectManager _projectManager;

        public TaskController(ITaskManager taskManager, IUserManager userManager, IProjectManager projectManager)
        {
            _taskManager = taskManager;
            _userManager = userManager;
            _projectManager = projectManager;
        }
        public async Task<IActionResult> Index(string search,PriorityLevel? priority,bool? isCompleted)
        {
            var tasks = await _taskManager.FilterTasksAsync(search,priority,isCompleted);

            TaskIndexVm vm = new()
            {
                Tasks = tasks,
                Search = search,
                Priority = priority,
                IsCompleted = isCompleted
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskManager.GetTaskDetailsAsync(id);

            if (task == null)
                return NotFound();

            TaskDetailsVm vm = new()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                IsCompleted = task.IsCompleted,
                //User = task.User,
                //Project = task.Project,
                //TaskComments = task.TaskComments?.ToList() ?? new()

                UserName = task.User.FirstName,
                ProjectName = task.Project.ProjectName,
                Comments = task.TaskComments?.ToList() ?? new()
            };

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            //TaskPageVm vm = new();

            //vm.Task = new ENTITIES.Models.Task();

            //vm.Users = await _userManager.GetAllAsync();

            //vm.Projects = await _projectManager.GetAllAsync();

            TaskCreateVm vm = new()
            {
                Users = await _userManager.GetAllAsync(),
                Projects = await _projectManager.GetAllAsync()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskCreateVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Users = await _userManager.GetAllAsync();
                vm.Projects = await _projectManager.GetAllAsync();

                return View(vm);
            }

            ENTITIES.Models.Task task = new()
            {
                Title = vm.Title,
                Description = vm.Description,
                Priority = vm.Priority,
                UserId = vm.UserId,
                ProjectId = vm.ProjectId
            };

            await _taskManager.CreateAsync(task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            TaskUpdateVm vm = new()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Priority = task.Priority,
                UserId = task.UserId,
                ProjectId = task.ProjectId,
                IsCompleted = task.IsCompleted,
                Users = await _userManager.GetAllAsync(),
                Projects = await _projectManager.GetAllAsync()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskUpdateVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Users = await _userManager.GetAllAsync();
                vm.Projects = await _projectManager.GetAllAsync();

                return View(vm);
            }

            var task = await _taskManager.GetByIdAsync(vm.Id);

            if (task == null)
                return NotFound();

            task.Title = vm.Title;
            task.Description = vm.Description;
            task.Priority = vm.Priority;
            task.UserId = vm.UserId;
            task.ProjectId = vm.ProjectId;
            task.IsCompleted = vm.IsCompleted;

            await _taskManager.UpdateAsync(task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            TaskDeleteVm vm = new()
            {
                Id = task.Id,
                Title = task.Title,
                UserName = task.User?.FirstName,
                ProjectName = task.Project?.ProjectName,
                IsCompleted = task.IsCompleted
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TaskDeleteVm vm)
        {
            var task = await _taskManager.GetByIdAsync(vm.Id);

            if (task == null)
                return NotFound();

            await _taskManager.MakePassiveAsync(task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CompleteTask(int id)
        {
            await _taskManager.CompleteTaskAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
