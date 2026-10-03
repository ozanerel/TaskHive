using System.Collections.Generic;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface IMessageManager
        : IManager<Message>
    {
        Task<Message> SendMessageAsync(int conversationId, int userId, string content);

        Task<List<Message>> GetMessagesByConversationAsync(int conversationId);

        Task<Message> GetLastMessageAsync(int conversationId);

        Task<int> GetUnreadMessageCountAsync(int userId);

        Task<int> GetUnreadConversationMessageCountAsync(int conversationId, int userId);

        Task<Message>GetLastMessageBeforeAsync(int conversationId,DateTime beforeDate);
    }
}