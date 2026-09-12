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
    }
}