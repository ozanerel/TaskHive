using System.Collections.Generic;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface IMessageRepository
        : IRepository<Message>
    {
        Task<List<Message>> GetMessagesByConversationAsync(
            int conversationId);

        Task<Message> GetLastMessageAsync(
            int conversationId);
    }
}