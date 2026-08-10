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
            //Mevcut kullanıcıyı buluyoruz
            var user = await _userContext.GetCurrentUserAsync();

            if (user == null)
                return View(0);

            var count = await _notificationManager
                .GetUnreadCountAsync(user.Id);

            return View(count);
        }

        //Repository'de bulunan filtre sayesinde sadece giriş yapan kullanıcının okunmamış aktif notificationları sayılıyor
    }
}