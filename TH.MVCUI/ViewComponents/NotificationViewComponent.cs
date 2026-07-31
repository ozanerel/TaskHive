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
            int count = 0;

            if (User.IsInRole("Admin"))
            {
                var notifications = await _notificationManager.GetAllAsync();

                count = notifications.Count(x => !x.IsRead);
            }
            else
            {
                var user = await _userContext.GetCurrentUserAsync();

                if (user != null)
                {
                    count = await _notificationManager
                        .GetUnreadCountAsync(user.Id);
                }
            }

            return View(count);
        }
    }
}