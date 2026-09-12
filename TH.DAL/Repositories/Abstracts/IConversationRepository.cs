using System.Collections.Generic;
using System.Threading.Tasks;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface IConversationRepository
        : IRepository<Conversation>
    {
        Task<Conversation> GetPrivateConversationAsync(
            int firstUserId,
            int secondUserId);

        Task<Conversation> GetTeamConversationAsync(
            int teamId);

        Task<List<Conversation>> GetUserConversationsAsync(
            int userId);
    }
}