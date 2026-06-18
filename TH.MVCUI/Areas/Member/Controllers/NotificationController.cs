using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;

namespace TH.MVCUI.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationManager _notificationManager;

        public NotificationController(INotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _notificationManager.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var notification = await _notificationManager.GetByIdAsync(id);

            if (notification == null)
                return NotFound();

            return View(notification);
        }

        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _notificationManager.MarkAsReadAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}