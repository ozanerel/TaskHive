using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.BLL.Managers.Concretes;
using TH.BLL.Services.Abstracts;
using TH.MVCUI.ViewComponents;

namespace TH.MVCUI.ViewComponents
{
    public class InviteNotificationViewComponent
        : ViewComponent
    {
        private readonly IUserContext _userContext;

        private readonly ITeamInvitationManager _teamInvitationManager;

        public InviteNotificationViewComponent(
            IUserContext userContext,
            ITeamInvitationManager teamInvitationManager)
        {
            _userContext =
                userContext;

            _teamInvitationManager =
                teamInvitationManager;
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
                await _teamInvitationManager
                    .GetUnreadInviteCountAsync(
                        user.Id);

            return View(count);
        }
    }
}