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
    public class ConversationParticipantRepository
        : BaseRepository<ConversationParticipant>,
          IConversationParticipantRepository
    {
        private readonly MyContext _context;

        public ConversationParticipantRepository(MyContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<ConversationParticipant>> GetParticipantsAsync(
            int conversationId)
        {
            return await _context.ConversationParticipants
                .Include(x => x.User)
                .Where(x =>
                    x.ConversationId == conversationId &&
                    x.Status != DataStatus.Deleted)
                .ToListAsync();
        }

        public async Task<bool> IsUserParticipantAsync(
            int conversationId,
            int userId)
        {
            return await _context.ConversationParticipants
                .AnyAsync(x =>
                    x.ConversationId == conversationId &&
                    x.UserId == userId &&
                    x.Status != DataStatus.Deleted);
        }

        public async Task<ConversationParticipant> GetParticipantAsync(
            int conversationId,
            int userId)
        {
            return await _context.ConversationParticipants
                .Include(x => x.User)
                .Include(x => x.Conversation)
                .FirstOrDefaultAsync(x =>
                    x.ConversationId == conversationId &&
                    x.UserId == userId &&
                    x.Status != DataStatus.Deleted);
        }

        public async Task<ConversationParticipant> GetParticipantIncludingDeletedAsync(int conversationId, int userId)
        {
            return await _context.ConversationParticipants
                .Include(x => x.User)
                .Include(x => x.Conversation)
                .FirstOrDefaultAsync(x => x.ConversationId == conversationId && x.UserId == userId);
        }
    }
}