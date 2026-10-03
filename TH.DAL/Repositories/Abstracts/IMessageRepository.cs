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

        Task<int> GetUnreadMessageCountAsync(
           int userId);

        Task<int> GetUnreadConversationMessageCountAsync(int conversationId,int userId);

        Task<int?> GetLastMessageIdAsync(int conversationId);

        Task<Message> GetLastMessageBeforeAsync(int conversationId,DateTime beforeDate);
    }
}