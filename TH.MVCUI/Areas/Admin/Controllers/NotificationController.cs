using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.MVCUI.Areas.Admin.Models.PageVMs;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationManager _notificationManager;

        public NotificationController(INotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public async Task<IActionResult> Index()
        {
            NotificationPageVm vm = new()
            {
                Notifications = await _notificationManager.GetAllAsync()
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var notification = await _notificationManager.GetByIdAsync(id);

            if (notification == null)
                return NotFound();

            NotificationPageVm vm = new()
            {
                Notification = notification
            };

            return View(vm);
        }

        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _notificationManager.MarkAsReadAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}