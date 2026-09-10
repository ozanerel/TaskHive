using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
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

        public async System.Threading.Tasks.Task CreateNotificationAsync(
            int userId,
            string title,
            string message,
            NotificationType type)
        {
            Notification notification = new()
            {
                UserId = userId,
                Title = title,
                Message = message,
                NotificationDate = DateTime.Now,
                IsRead = false,
                Type = type
            };

            await CreateAsync(notification);
        }

        public async Task<List<Notification>> GetNotificationsByUserAsync(int userId)
        {
            return await _repository.GetNotificationsByUserAsync(userId);
        }

        public async Task<List<Notification>> GetUnreadNotificationsAsync(int userId)
        {
            return await _repository.GetUnreadNotificationsAsync(userId);
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _repository.GetUnreadCountAsync(userId);
        }

        public async System.Threading.Tasks.Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _repository.GetByIdAsync(notificationId);

            if (notification == null)
                return;

            if (notification.Status == DataStatus.Deleted)
                return;

            if (notification.IsRead)
                return;

            notification.IsRead = true;

            await _repository.UpdateAsync(notification, notification);
        }
    }

}
