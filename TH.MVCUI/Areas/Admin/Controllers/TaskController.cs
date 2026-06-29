using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Managers.Concretes;
using TH.MVCUI.Areas.Admin.Models.PageVMs;

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
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskManager.GetAllAsync();

            TaskPageVm vm = new()
            {
                Tasks = tasks
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            TaskPageVm vm = new()
            {
                Task = task
            };

            return View(vm);
        }

        public async Task<IActionResult> Create()
        {
            TaskPageVm vm = new();

            vm.Task = new ENTITIES.Models.Task();

            vm.Users = await _userManager.GetAllAsync();

            vm.Projects = await _projectManager.GetAllAsync();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskPageVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Users = await _userManager.GetAllAsync();
                vm.Projects = await _projectManager.GetAllAsync();

                return View(vm);
            }

            await _taskManager.CreateAsync(vm.Task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            TaskPageVm vm = new()
            {
                Task = task,
                Users = await _userManager.GetAllAsync(),
                Projects = await _projectManager.GetAllAsync()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TaskPageVm vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Users = await _userManager.GetAllAsync();
                vm.Projects = await _projectManager.GetAllAsync();

                return View(vm);
            }

            await _taskManager.UpdateAsync(vm.Task);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskManager.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            TaskPageVm vm = new()
            {
                Task = task
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(TaskPageVm vm)
        {
            var task = await _taskManager.GetByIdAsync(vm.Task.Id);

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
