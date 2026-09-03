using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;
using TH.MVCUI.Models.ViewModels.TeamViewModels;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class TeamInvitationController : Controller
    {
        private readonly ITeamInvitationManager _teamInvitationManager;
        private readonly IUserManager _userManager;
        private readonly UserManager<AppUser> _identityUserManager;

        public TeamInvitationController(
            ITeamInvitationManager teamInvitationManager,
            IUserManager userManager,
            UserManager<AppUser> identityUserManager)
        {
            _teamInvitationManager = teamInvitationManager;
            _userManager = userManager;
            _identityUserManager = identityUserManager;
        }

        // GET: /Member/TeamInvitation/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appUser =
                await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { area = "" });

            var currentUser =
                await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var invitations =
                await _teamInvitationManager
                    .GetUserInvitationsAsync(currentUser.Id);

            var model = invitations
                .Select(x => new TeamInvitationViewModel
                {
                    Id = x.Id,
                    TeamId = x.TeamId,
                    TeamName = x.Team?.Name,
                    InvitedByUserId = x.InvitedByUserId,
                    InvitedByUserName =
                        x.InvitedByUser != null
                            ? $"{x.InvitedByUser.FirstName} {x.InvitedByUser.LastName}"
                            : "Bilinmeyen Kullanıcı",
                    CreatedDate = x.CreatedDate,
                    InvitationStatus = x.InvitationStatus
                })
                .ToList();

            return View(model);
        }

        // POST: /Member/TeamInvitation/Accept
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            var appUser =
                await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { area = "" });

            var currentUser =
                await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var result =
                await _teamInvitationManager
                    .AcceptInvitationAsync(
                        id,
                        currentUser.Id);

            if (!result)
            {
                TempData["Error"] =
                    "Davet bulunamadı veya bu daveti kabul etme yetkiniz yok.";

                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] =
                "Takım daveti başarıyla kabul edildi.";

            return RedirectToAction(nameof(Index));
        }

        // POST: /Member/TeamInvitation/Reject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var appUser =
                await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { area = "" });

            var currentUser =
                await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
                return NotFound();

            var result =
                await _teamInvitationManager
                    .RejectInvitationAsync(
                        id,
                        currentUser.Id);

            if (!result)
            {
                TempData["Error"] =
                    "Davet bulunamadı veya bu daveti reddetme yetkiniz yok.";

                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] =
                "Takım daveti reddedildi.";

            return RedirectToAction(nameof(Index));
        }
    }
}

//Burada invite olmamasının sebebi member kullanıcının herhangi bir takıma davet gönderemez