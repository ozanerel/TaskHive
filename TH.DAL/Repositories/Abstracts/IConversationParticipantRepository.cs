using System.Collections.Generic;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface IConversationParticipantRepository
        : IRepository<ConversationParticipant>
    {
        Task<List<ConversationParticipant>> GetParticipantsAsync(
            int conversationId);

        Task<bool> IsUserParticipantAsync(
            int conversationId,
            int userId);

        Task<ConversationParticipant> GetParticipantAsync(
            int conversationId,
            int userId);

        Task<ConversationParticipant> GetParticipantIncludingDeletedAsync(
            int conversationId,
            int userId);
    }
}