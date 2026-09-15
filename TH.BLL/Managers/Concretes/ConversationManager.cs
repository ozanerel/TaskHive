using System.Collections.Generic;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class ConversationManager
        : BaseManager<Conversation>,
          IConversationManager
    {
        private readonly IConversationParticipantManager
            _conversationParticipantManager;

        private readonly IUserManager _userManager;

        private readonly ITeamManager _teamManager;

        private readonly ITeamMemberManager _teamMemberManager;

        private readonly IConversationRepository _repository;

        public ConversationManager(
            IConversationRepository repository,
            IConversationParticipantManager conversationParticipantManager,
            IUserManager userManager,
            ITeamManager teamManager,
            ITeamMemberManager teamMemberManager)
            : base(repository)
        {
            _conversationParticipantManager =
                conversationParticipantManager;

            _userManager = userManager;
            _teamManager = teamManager;
            _teamMemberManager = teamMemberManager;
            _repository = repository;

        }

        public async Task<Conversation>
            GetOrCreatePrivateConversationAsync(
                int firstUserId,
                int secondUserId)
        {
            if (firstUserId <= 0 ||
                secondUserId <= 0 ||
                firstUserId == secondUserId)
            {
                return null;
            }

            var firstUser =
                await _userManager.GetByIdAsync(firstUserId);

            var secondUser =
                await _userManager.GetByIdAsync(secondUserId);

            if (firstUser == null ||
                secondUser == null)
            {
                return null;
            }

            if (firstUser.Status == DataStatus.Deleted ||
                secondUser.Status == DataStatus.Deleted)
            {
                return null;
            }

            var existingConversation =
                await ((IConversationRepository)_repository)
                    .GetPrivateConversationAsync(
                        firstUserId,
                        secondUserId);

            if (existingConversation != null)
            {
                return existingConversation;
            }

            var conversation = new Conversation
            {
                Type = ConversationType.Private
            };

            await base.CreateAsync(conversation);

            await _conversationParticipantManager
                .AddParticipantAsync(
                    conversation.Id,
                    firstUserId);

            await _conversationParticipantManager
                .AddParticipantAsync(
                    conversation.Id,
                    secondUserId);

            return conversation;
        }

        public async Task<Conversation>
            GetOrCreateTeamConversationAsync(int teamId)
        {
            if (teamId <= 0)
            {
                return null;
            }

            var team =
                await _teamManager.GetByIdAsync(teamId);

            if (team == null ||
                team.Status == DataStatus.Deleted)
            {
                return null;
            }

            var existingConversation =
                await ((IConversationRepository)_repository)
                    .GetTeamConversationAsync(teamId);

            if (existingConversation != null)
            {
                return existingConversation;
            }

            var conversation = new Conversation
            {
                Type = ConversationType.Team,
                TeamId = teamId
            };

            await base.CreateAsync(conversation);

            // Takımın mevcut üyelerini sohbete ekliyoruz.
            var teamMembers =
                await _teamMemberManager
                    .GetTeamMembersAsync(teamId);

            if (teamMembers != null)
            {
                foreach (var teamMember in teamMembers)
                {
                    await _conversationParticipantManager
                        .AddParticipantAsync(
                            conversation.Id,
                            teamMember.UserId);
                }
            }

            return conversation;
        }

        public async Task<Conversation> GetTeamConversationAsync(int teamId)
        {
            if (teamId <= 0)
            {
                return null;
            }

            return await _repository
                .GetTeamConversationAsync(teamId);
        }

        public async Task<List<Conversation>>
            GetUserConversationsAsync(int userId)
        {
            if (userId <= 0)
            {
                return new List<Conversation>();
            }

            return await ((IConversationRepository)_repository)
                .GetUserConversationsAsync(userId);
        }
    }
}