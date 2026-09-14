using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using TH.MVCUI.Areas.Member.Models.PageVMs.ChatVM;

namespace TH.MVCUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class ChatController : Controller
    {
        private readonly IConversationManager _conversationManager;

        private readonly IMessageManager _messageManager;

        private readonly IConversationParticipantManager _conversationParticipantManager;

        private readonly UserManager<AppUser> _identityUserManager;

        private readonly IUserManager _userManager;

        public ChatController(
            IConversationManager conversationManager,
            IMessageManager messageManager,
            IConversationParticipantManager conversationParticipantManager,
            UserManager<AppUser> identityUserManager,
            IUserManager userManager)
        {
            _conversationManager = conversationManager;

            _messageManager = messageManager;

            _conversationParticipantManager = conversationParticipantManager;

            _identityUserManager = identityUserManager;

            _userManager = userManager;
        }

        // Kullanıcının konuşmalarını listeler.
        public async Task<IActionResult> Index()
        {
            var appUser =
                await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { area = "" });
            }

            var currentUser =
                await _userManager
                    .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
            {
                return NotFound();
            }

            var conversations =
                await _conversationManager
                    .GetUserConversationsAsync(
                        currentUser.Id);

            var model =
                new List<ConversationListVm>();

            foreach (var conversation in conversations)
            {
                var lastMessage =
                    await _messageManager
                        .GetLastMessageAsync(
                            conversation.Id);

                model.Add(new ConversationListVm
                {
                    Id = conversation.Id,

                    Title =
                        $"Conversation #{conversation.Id}",

                    LastMessageContent =
                        lastMessage?.Content,

                    LastMessageDate =
                        lastMessage?.CreatedDate,

                    UnreadMessageCount = 0,

                    IsTeamConversation =
                        conversation.Type ==
                        ConversationType.Team
                });
            }

            return View(model);
        }

        // Seçilen konuşmayı ve mesajlarını gösterir.
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            // Giriş yapan Identity kullanıcısını al.
            var appUser =
                await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { area = "" });
            }

            // Identity kullanıcısına bağlı domain User kaydını al.
            var currentUser =
                await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
            {
                return NotFound();
            }

            var conversation =
                await _conversationManager
                    .GetByIdAsync(id);

            if (conversation == null)
            {
                return NotFound();
            }

            // Burada domain User.Id kullanılmalı.
            var isParticipant =
                await _conversationParticipantManager
                    .IsUserParticipantAsync(
                        id,
                        currentUser.Id);

            if (!isParticipant)
            {
                return Forbid();
            }

            var messages =
                await _messageManager
                    .GetMessagesByConversationAsync(id);

            var messageModels =
                new List<MessageListVm>();

            foreach (var message in messages)
            {
                var messageUser =
                    await _userManager
                        .GetByIdAsync(message.UserId);

                var messageAppUser = messageUser == null
                    ? null
                    : await _identityUserManager
                        .FindByIdAsync(
                            messageUser.AppUserId.ToString());

                messageModels.Add(new MessageListVm
                {
                    Id = message.Id,

                    ConversationId =
                        message.ConversationId,

                    UserId =
                        message.UserId,

                    UserName =
                        messageAppUser?.UserName
                        ?? "Kullanıcı",

                    Content =
                        message.Content,

                    CreatedDate =
                        message.CreatedDate,

                    IsMine =
                        message.UserId ==
                        currentUser.Id
                });
            }

            var model = new ConversationDetailsVm
            {
                Id = conversation.Id,

                Title =
                    $"Conversation #{conversation.Id}",

                IsTeamConversation =
                    conversation.Type ==
                    ConversationType.Team,

                TeamId =
                    conversation.TeamId,

                Messages =
                    messageModels,

                SendMessage =
                    new SendMessageVm
                    {
                        ConversationId =
                            conversation.Id
                    }
            };

            return View(model);
        }

        // Özel sohbet başlatır veya mevcut özel sohbeti açar.
        public async Task<IActionResult> StartPrivateChat(int userId)
        {
            if (userId <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var appUser =
                await _identityUserManager
                    .GetUserAsync(User);

            if (appUser == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { area = "" });
            }

            var currentUser =
                await _userManager
                    .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
            {
                return NotFound();
            }

            if (currentUser.Id == userId)
            {
                return BadRequest();
            }

            var targetUser =
                await _userManager
                    .GetByIdAsync(userId);

            if (targetUser == null)
            {
                return NotFound();
            }

            if (targetUser.Status == DataStatus.Deleted)
            {
                return NotFound();
            }

            var conversation =
                await _conversationManager
                    .GetOrCreatePrivateConversationAsync(
                        currentUser.Id,
                        targetUser.Id);

            if (conversation == null)
            {
                return BadRequest();
            }

            return RedirectToAction(
                nameof(Details),
                new
                {
                    id = conversation.Id
                });
        }

        // Takım sohbetini açar veya oluşturur.
        public async Task<IActionResult> OpenTeamChat(int teamId)
        {
            if (teamId <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var appUser =
                await _identityUserManager
                    .GetUserAsync(User);

            if (appUser == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { area = "" });
            }

            var currentUser =
                await _userManager
                    .GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
            {
                return NotFound();
            }

            var conversation =
                await _conversationManager
                    .GetOrCreateTeamConversationAsync(
                        teamId);

            if (conversation == null)
            {
                return NotFound();
            }

            var isParticipant =
                await _conversationParticipantManager
                    .IsUserParticipantAsync(
                        conversation.Id,
                        currentUser.Id);

            if (!isParticipant)
            {
                return Forbid();
            }

            return RedirectToAction(
                nameof(Details),
                new
                {
                    id = conversation.Id
                });
        }

        // Mesaj gönderir.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(SendMessageVm model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(
                    nameof(Details),
                    new
                    {
                        id = model.ConversationId
                    });
            }

            // Giriş yapan Identity kullanıcısını al.
            var appUser =
                await _identityUserManager.GetUserAsync(User);

            if (appUser == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account",
                    new { area = "" });
            }

            // Identity kullanıcısına bağlı domain User kaydını al.
            var currentUser =
                await _userManager.GetByAppUserIdAsync(appUser.Id);

            if (currentUser == null)
            {
                return NotFound();
            }

            // Katılımcı kontrolünde domain User.Id kullanılmalı.
            var isParticipant =
                await _conversationParticipantManager
                    .IsUserParticipantAsync(
                        model.ConversationId,
                        currentUser.Id);

            if (!isParticipant)
            {
                return Forbid();
            }

            var message =
                await _messageManager
                    .SendMessageAsync(
                        model.ConversationId,
                        currentUser.Id,
                        model.Content);

            if (message == null)
            {
                return BadRequest();
            }

            return RedirectToAction(
                nameof(Details),
                new
                {
                    id = model.ConversationId
                });
        }
    }
}
