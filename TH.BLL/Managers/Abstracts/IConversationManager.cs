using System.Collections.Generic;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface IConversationManager
        : IManager<Conversation>
    {
        Task<Conversation>
            GetOrCreatePrivateConversationAsync(
                int firstUserId,
                int secondUserId);

        Task<Conversation>
            GetOrCreateTeamConversationAsync(
                int teamId);

        Task<List<Conversation>>
            GetUserConversationsAsync(
                int userId);
    }
}