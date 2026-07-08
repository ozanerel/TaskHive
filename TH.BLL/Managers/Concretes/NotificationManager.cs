using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.DAL.Repositories.Concretes;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class NotificationManager : BaseManager<Notification>, INotificationManager
    {
        private readonly INotificationRepository _repository;

        public NotificationManager(INotificationRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<Notification>> GetNotificationsByUserAsync(int userId)
        {
            return await _repository
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _repository
                .Where(x => x.UserId == userId &&
                            !x.IsRead &&
                            x.Status != DataStatus.Deleted)
                .CountAsync();
        }

        public async Task<List<Notification>> GetUnreadNotificationsAsync(int userId)
        {
            return _repository
                .Where(x => x.UserId == userId && !x.IsRead)
                .ToList();
        }

        public async System.Threading.Tasks.Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _repository.GetByIdAsync(notificationId);

            if (notification == null)
                return;

            notification.IsRead = true;

            await _repository.UpdateAsync(notification, notification);
        }
    }
}
