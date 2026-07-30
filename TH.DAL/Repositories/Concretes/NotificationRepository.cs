using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class NotificationRepository:BaseRepository<Notification>, INotificationRepository
    {
        readonly MyContext _context;
        public NotificationRepository(MyContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetUnreadNotificationsAsync(int userId)
        {
            return await _context.Notifications
                .Where(x => x.UserId == userId && !x.IsRead)
                .OrderByDescending(x => x.NotificationDate)
                .ToListAsync();
        }

        public async Task<List<Notification>> GetNotificationsByUserAsync(int userId)
        {
            return await _context.Notifications
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.NotificationDate)
                .ToListAsync();
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _context.Notifications
                .CountAsync(x => x.UserId == userId && !x.IsRead);
        }
    }
}
