using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.ENTITIES.Enums;
using TH.MVCUI.Areas.Admin.Models.PageVMs.NotificationVM;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationManager _notificationManager;
        private readonly IUserContext _userContext;

        public NotificationController(
            INotificationManager notificationManager,
            IUserContext userContext)
        {
            _notificationManager = notificationManager;
            _userContext = userContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            NotificationIndexVm vm = new()
            {
                Notifications = await _notificationManager
                    .GetNotificationsByUserAsync(user.Id)
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var notification = await _notificationManager.GetByIdAsync(id);

            if (notification == null)
                return NotFound();

            // Kullanıcı sadece kendi notification'ını görebilir.
            if (notification.UserId != user.Id)
                return Forbid();

            if (notification.Status == DataStatus.Deleted)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return NotFound();

            var notification = await _notificationManager.GetByIdAsync(id);

            if (notification == null)
                return NotFound();

            // Kullanıcı sadece kendi notification'ını okuyabilir.
            if (notification.UserId != user.Id)
                return Forbid();

            if (notification.Status == DataStatus.Deleted)
                return NotFound();

            await _notificationManager.MarkAsReadAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}