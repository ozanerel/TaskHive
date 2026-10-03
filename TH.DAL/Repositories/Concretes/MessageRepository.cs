using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class MessageRepository
        : BaseRepository<Message>, IMessageRepository
    {
        private readonly MyContext _context;

        public MessageRepository(MyContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetMessagesByConversationAsync(
            int conversationId)
        {
            return await _context.Messages
                .Include(x => x.User)
                .Where(x =>
                    x.ConversationId == conversationId &&
                    x.Status != DataStatus.Deleted)
                .OrderBy(x => x.CreatedDate)
                .ToListAsync();
        }

        public async Task<Message> GetLastMessageAsync(
            int conversationId)
        {
            return await _context.Messages
                .Include(x => x.User)
                .Where(x =>
                    x.ConversationId == conversationId &&
                    x.Status != DataStatus.Deleted)
                .OrderByDescending(x => x.CreatedDate)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetUnreadMessageCountAsync(int userId)
        {
            if (userId <= 0)
            {
                return 0;
            }

            var unreadCount = await
                (
                    from message in _context.Messages

                    join participant
                        in _context.ConversationParticipants
                        on message.ConversationId
                        equals participant.ConversationId

                    where
                        participant.UserId == userId &&

                        participant.Status != DataStatus.Deleted &&

                        message.Status != DataStatus.Deleted &&

                        // Kullanıcının kendi mesajı okunmamış sayılmaz.
                        message.UserId != userId &&

                        (
                            participant.LastReadMessageId == null ||
                            message.Id > participant.LastReadMessageId
                        )

                    select message.Id
                )
                .CountAsync();

            return unreadCount;

        }

        public async Task<int?> GetLastMessageIdAsync(int conversationId)
        {
            if (conversationId <= 0)
            {
                return null;
            }

            return await _context.Messages
                .Where(x =>
                    x.ConversationId == conversationId &&
                    x.Status != DataStatus.Deleted)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => (int?)x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Message> GetLastMessageBeforeAsync(int conversationId, DateTime beforeDate)
        {
            return await _context.Messages
                .Include(x => x.User)
                .Where(x => 
                x.ConversationId == conversationId &&
                x.Status != DataStatus.Deleted &&
                x.CreatedDate <= beforeDate)
                .OrderByDescending(x => x.CreatedDate)
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetUnreadConversationMessageCountAsync(int conversationId, int userId)
        {
            if (conversationId <= 0 || userId <= 0)
            {
                return 0;
            }

            var participant = await _context.ConversationParticipants
                .Where(x =>
                    x.ConversationId == conversationId &&
                    x.UserId == userId &&
                    x.Status != DataStatus.Deleted)
                .FirstOrDefaultAsync();

            if (participant == null)
            {
                return 0;
            }

            var unreadCount = await _context.Messages
                .Where(x =>
                    x.ConversationId == conversationId &&
                    x.Status != DataStatus.Deleted &&
                    x.UserId != userId &&
                    (
                        participant.LastReadMessageId == null ||
                        x.Id > participant.LastReadMessageId
                    ))
                .CountAsync();

            return unreadCount;
        }
    }
}