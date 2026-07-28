using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.MVCUI.Areas.Admin.Models.PageVMs;
using TH.MVCUI.Areas.Admin.Models.PageVMs.NotificationVM;

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
            NotificationIndexVm vm = new()
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

            NotificationDetailsVm vm = new()
            {
                Id = notification.Id,
                Title = notification.Title,
                Message = notification.Message,
                NotificationDate = notification.NotificationDate,
                IsRead = notification.IsRead,
                User = notification.User
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