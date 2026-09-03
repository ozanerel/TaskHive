using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.MVCUI.Models.ViewModels.TeamViewModels;

namespace TH.MVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TeamInvitationController : Controller
    {
        private readonly ITeamInvitationManager _teamInvitationManager;
        private readonly IUserManager _userManager;
        private readonly UserManager<AppUser> _identityUserManager;
        private readonly ITeamMemberManager _teamMemberManager;
        private readonly ITeamManager _teamManager;

        public TeamInvitationController(
            ITeamInvitationManager teamInvitationManager,
            IUserManager userManager,
            UserManager<AppUser> identityUserManager,
            ITeamMemberManager teamMemberManager,
            ITeamManager teamManager)
        {
            _teamInvitationManager = teamInvitationManager;
            _userManager = userManager;
            _identityUserManager = identityUserManager;
            _teamMemberManager = teamMemberManager;
            _teamManager = teamManager;
        }

        // GET: /Admin/TeamInvitation/Index
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

        // POST: /Admin/TeamInvitation/Accept
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

        // POST: /Admin/TeamInvitation/Reject
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

        // POST: /Admin/TeamInvitation/Invite
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invite(
            int teamId,
            int userId)
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

            var currentMember =
                await _teamMemberManager.GetTeamMemberAsync(
                    teamId,
                    currentUser.Id);

            if (currentMember == null ||
                currentMember.TeamRole != TeamRole.Admin)
            {
                return Forbid();
            }

            var team =
                await _teamManager.GetByIdAsync(teamId);

            if (team == null ||
                team.Status == DataStatus.Deleted)
            {
                return NotFound();
            }

            var invitedUser =
                await _userManager.GetByIdAsync(userId);

            if (invitedUser == null ||
                invitedUser.Status == DataStatus.Deleted)
            {
                TempData["Error"] =
                    "Davet gönderilecek kullanıcı bulunamadı.";

                return RedirectToAction(
                    "Index",
                    "Search",
                    new { area = "Admin" });
            }

            if (invitedUser.Id == currentUser.Id)
            {
                TempData["Error"] =
                    "Kendinize takım daveti gönderemezsiniz.";

                return RedirectToAction(
                    "Index",
                    "Search",
                    new { area = "Admin" });
            }

            var isAlreadyMember =
                await _teamMemberManager.IsUserInTeamAsync(
                    teamId,
                    invitedUser.Id);

            if (isAlreadyMember)
            {
                TempData["Error"] =
                    "Bu kullanıcı zaten takımın üyesi.";

                return RedirectToAction(
                    "Index",
                    "Search",
                    new { area = "Admin" });
            }

            var result =
                await _teamInvitationManager
                    .SendInvitationAsync(
                        teamId,
                        invitedUser.Id,
                        currentUser.Id);

            if (!result)
            {
                TempData["Error"] =
                    "Bu kullanıcıya zaten bekleyen bir davet gönderilmiş.";

                return RedirectToAction(
                    "Index",
                    "Search",
                    new { area = "Admin" });
            }

            TempData["Success"] =
                $"{invitedUser.FirstName} {invitedUser.LastName} kullanıcısına takım daveti gönderildi.";

            return RedirectToAction(
                "Index",
                "Search",
                new { area = "Admin" });
        }
    }
}