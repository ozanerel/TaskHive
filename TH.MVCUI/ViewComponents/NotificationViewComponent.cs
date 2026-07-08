using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;

namespace TH.MVCUI.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly IUserContext _userContext;
        private readonly INotificationManager _notificationManager;

        public NotificationViewComponent(
            IUserContext userContext,
            INotificationManager notificationManager)
        {
            _userContext = userContext;
            _notificationManager = notificationManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return View(0);

            var notifications =
                await _notificationManager.GetUnreadNotificationsAsync(user.Id);

            return View(notifications.Count);
        }
    }
}