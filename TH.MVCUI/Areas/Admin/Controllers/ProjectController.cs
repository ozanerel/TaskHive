using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using Microsoft.AspNetCore.Authorization;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Admin.Models.PageVMs.ProjectVM;
using TH.ENTITIES.Enums;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectManager _projectManager;
        private readonly IUserManager _userManager;
        private readonly INotificationManager _notificationManager;

        public ProjectController(IProjectManager projectManager, IUserManager userManager,INotificationManager notificationManager)
        {
            _projectManager = projectManager;
            _userManager = userManager;
            _notificationManager = notificationManager;
        }

        // Proje Listesi
        public async Task<IActionResult> Index()
        {
            var projects = await _projectManager.GetProjectsWithTasksAsync();

            ProjectIndexVm vm = new()
            {
                Projects = projects
            };

            return View(vm);
        }

        // Proje Detayı
        public async Task<IActionResult> Details(int id)
        {
            var project = await _projectManager.GetProjectDetailsAsync(id);

            if (project == null)
                return NotFound();

            ProjectDetailsVm vm = new ProjectDetailsVm
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                Tasks = project.Tasks?.ToList() ?? new(),
                Users = project.Users?.ToList() ?? new(),
                CreatedDate = project.CreatedDate
            };

            return View(vm);
        }

        // GET
        public async Task<IActionResult> Create()
        {
            ProjectCreateVm vm = new()
            {
                Users = await _userManager.GetAllAsync()
            };
            //vm.Project = new Project(); // Initialize the Project property

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectCreateVm vm)
        {
            //if (!ModelState.IsValid)
            //    return View(vm);

            //await _projectManager.CreateAsync(vm.Project);

            //return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid)
                return View(vm);


            Project project = new Project
            {
                ProjectName = vm.ProjectName,
                Description = vm.Description,
                Users = new List<User>(),

            };

            foreach (var id in vm.UserIds)
            {
                var user = await _userManager.GetByIdAsync(id);

                if (user != null)
                {
                    project.Users.Add(user);
                }
            }

            await _projectManager.CreateAsync(project);


            return RedirectToAction(nameof(Index));

        }

        // GET
        public async Task<IActionResult> Update(int id)
        {
            //var project = await _projectManager.GetByIdAsync(id);
            var project = await _projectManager.GetProjectDetailsAsync(id);

            if (project == null)
                return NotFound();

            //ProjectPageVm vm = new ProjectPageVm
            //{
            //    Project = project
            //};

            ProjectUpdateVm vm = new()
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                UserIds = project.Users
                .Select(x => x.Id)
                .ToList(),

                Users = await _userManager.GetAllAsync()
            };

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ProjectUpdateVm vm)
        {
            //if (!ModelState.IsValid)
            //    return View(vm);

            if (!ModelState.IsValid)
            {
                vm.Users = await _userManager.GetAllAsync();
                return View(vm);
            }

            var project = await _projectManager.GetProjectDetailsAsync(vm.Id);

            if (project == null)
                return NotFound();

            project.ProjectName = vm.ProjectName;
            project.Description = vm.Description;

            var oldUsers = project.Users.ToList();

            // Önce mevcut kullanıcıları temizle
            project.Users.Clear();

            // Yeni seçilen kullanıcıları ekle
            foreach (var userId in vm.UserIds)
            {
                var user = await _userManager.GetByIdAsync(userId);

                if (user != null)
                {
                    project.Users.Add(user);
                }
            }

            //Eklenen kullanıcıları bulma
            var addedUsers = project.Users
                .Where(x => !oldUsers.Any(y => y.Id == x.Id))
                .ToList();

            //Çıkarılan kullanıcıları bulma 
            var removedUsers = oldUsers
                .Where(x => !project.Users.Any(y => y.Id == x.Id))
                .ToList();

            foreach (var user in addedUsers)
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "Project Updated",
                    $"You have been added to project '{project.ProjectName}'.",
                    NotificationType.ProjectUpdated
                );
            }

            foreach (var user in removedUsers)
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "Project Updated",
                    $"You have been removed from project '{project.ProjectName}'.",
                    NotificationType.ProjectUpdated
                );
            }


            await _projectManager.UpdateAsync(project);

            return RedirectToAction(nameof(Index));
        }

        // GET
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectManager.GetByIdAsync(id);

            if (project == null)
                return NotFound();

            //ProjectPageVm vm = new ProjectPageVm
            //{
            //    Project = project
            //};

            ProjectDeleteVm vm = new ProjectDeleteVm
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description
            };

            return View(vm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProjectDeleteVm vm)
        {
            Project project = new()
            {
                Id = vm.Id
            };

            await _projectManager.MakePassiveAsync(project);

            return RedirectToAction(nameof(Index));
        }
    }
}