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
    public class ConversationRepository
        : BaseRepository<Conversation>, IConversationRepository
    {
        private readonly MyContext _context;

        public ConversationRepository(MyContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<Conversation> GetPrivateConversationAsync(
            int firstUserId,
            int secondUserId)
        {
            return await _context.Conversations
                .Include(x => x.Participants)
                .Include(x => x.Messages)
                .Where(x =>
                    x.Type == ConversationType.Private &&
                    x.Status != DataStatus.Deleted &&
                    x.Participants.Any(p => p.UserId == firstUserId) &&
                    x.Participants.Any(p => p.UserId == secondUserId))
                .FirstOrDefaultAsync();
        }

        public async Task<Conversation> GetTeamConversationAsync(
            int teamId)
        {
            return await _context.Conversations
                .Include(x => x.Team)
                .Include(x => x.Participants)
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x =>
                    x.TeamId == teamId &&
                    x.Type == ConversationType.Team &&
                    x.Status != DataStatus.Deleted);
        }

        public async Task<List<Conversation>> GetUserConversationsAsync(int userId)
        {
            return await _context.Conversations
                .Include(x => x.Team)
                .Include(x => x.Participants)
                    .ThenInclude(x => x.User)
                .Include(x => x.Messages)
                .Where(x =>
                    x.Status != DataStatus.Deleted &&
                    x.Participants.Any(p => p.UserId == userId))
                .ToListAsync();
        }
    }
}