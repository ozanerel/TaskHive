using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Services.Abstracts;

namespace TH.MVCUI.ViewComponents
{
    public class MessageNotificationViewComponent
        : ViewComponent
    {
        private readonly IUserContext _userContext;

        private readonly IMessageManager _messageManager;

        public MessageNotificationViewComponent(
            IUserContext userContext,
            IMessageManager messageManager)
        {
            _userContext =
                userContext;

            _messageManager =
                messageManager;
        }

        public async Task<IViewComponentResult>
            InvokeAsync()
        {
            var user =
                await _userContext
                    .GetCurrentUserAsync();

            if (user == null)
            {
                return View(0);
            }

            var count =
                await _messageManager
                    .GetUnreadMessageCountAsync(
                        user.Id);

            return View(count);
        }
    }
}