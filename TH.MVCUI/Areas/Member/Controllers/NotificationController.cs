using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;
using TH.MVCUI.Areas.Member.Models.PageVMs;
using TH.MVCUI.Areas.Member.Models.PageVMs.NotificationVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class NotificationController : Controller
    {
        private readonly INotificationManager _notificationManager;
        private readonly IUserContext _userContext;

        public NotificationController(INotificationManager notificationManager,IUserContext userContext)
        {
            _notificationManager = notificationManager;
            _userContext = userContext;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userContext.GetCurrentUserAsync();

            NotificationIndexVm vm = new()
            {
                Notifications = await _notificationManager
                    .GetUnreadNotificationsAsync(user.Id)
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var notification = await _notificationManager.GetByIdAsync(id);

            if (notification == null)
                return NotFound();

            var user = await _userContext.GetCurrentUserAsync();

            if (notification.UserId != user.Id)
                return Forbid();

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