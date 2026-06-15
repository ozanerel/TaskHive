using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;

namespace TH.MVCUI.Controllers
{
    public class TaskCommentController : Controller
    {
        private readonly ITaskCommentManager _taskCommentManager;

        public TaskCommentController(ITaskCommentManager taskCommentManager)
        {
            _taskCommentManager = taskCommentManager;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _taskCommentManager.GetAllAsync();

            return View(comments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskComment comment)
        {
            if (!ModelState.IsValid)
                return View(comment);

            await _taskCommentManager.CreateAsync(comment);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            return View(comment);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var comment = await _taskCommentManager.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskComment comment)
        {
            if (!ModelState.IsValid)
                return View(comment);

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

        [HttpPost]
        public async Task<IActionResult> Delete(TaskComment comment)
        {
            await _taskCommentManager.MakePassiveAsync(comment);

            return RedirectToAction(nameof(Index));
        }
    }
}