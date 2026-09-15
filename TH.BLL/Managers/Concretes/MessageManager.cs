using System.Collections.Generic;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class MessageManager
        : BaseManager<Message>,
          IMessageManager
    {
        private readonly IConversationParticipantManager
            _conversationParticipantManager;

        private readonly IMessageRepository _repository;

        public MessageManager(
            IMessageRepository repository,
            IConversationParticipantManager conversationParticipantManager)
            : base(repository)
        {
            _conversationParticipantManager =
                conversationParticipantManager;

            _repository =
                repository;
        }

        public async Task<Message>
            SendMessageAsync(
                int conversationId,
                int userId,
                string content)
        {
            if (conversationId <= 0 ||
                userId <= 0 ||
                string.IsNullOrWhiteSpace(content))
            {
                return null;
            }

            var isParticipant =
                await _conversationParticipantManager
                    .IsUserParticipantAsync(
                        conversationId,
                        userId);

            if (!isParticipant)
            {
                return null;
            }

            var message = new Message
            {
                ConversationId =
                    conversationId,

                UserId =
                    userId,

                Content =
                    content.Trim()
            };

            await base.CreateAsync(message);

            return message;
        }

        public async Task<List<Message>>
            GetMessagesByConversationAsync(
                int conversationId)
        {
            if (conversationId <= 0)
            {
                return new List<Message>();
            }

            return await _repository
                .GetMessagesByConversationAsync(
                    conversationId);
        }

        public async Task<Message>
            GetLastMessageAsync(
                int conversationId)
        {
            if (conversationId <= 0)
            {
                return null;
            }

            return await _repository
                .GetLastMessageAsync(
                    conversationId);
        }

        public async Task<int> GetUnreadMessageCountAsync(int userId)
        {
            if (userId <= 0)
            {
                return 0;
            }

            return await _repository.GetUnreadMessageCountAsync(userId);
        }
    }
}