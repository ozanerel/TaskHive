using System.Collections.Generic;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface IConversationParticipantManager
        : IManager<ConversationParticipant>
    {
        System.Threading.Tasks.Task AddParticipantAsync(
            int conversationId,
            int userId);

        System.Threading.Tasks.Task RemoveParticipantAsync(
            int conversationId,
            int userId);

        Task<List<ConversationParticipant>>
            GetParticipantsAsync(int conversationId);

        Task<bool> IsUserParticipantAsync(
            int conversationId,
            int userId);

        Task<ConversationParticipant>
            GetParticipantAsync(
                int conversationId,
                int userId);

        System.Threading.Tasks.Task MarkConversationAsReadAsync(
            int conversationId,
            int userId);


        Task<ConversationParticipant>
             GetParticipantIncludingDeletedAsync(
             int conversationId,
             int userId);
    }
}