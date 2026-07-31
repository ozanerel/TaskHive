using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Abstracts
{
    public interface INotificationManager:IManager<Notification>
    {
        Task MarkAsReadAsync(int notificationId);

        Task<List<Notification>> GetUnreadNotificationsAsync(int userId);
        Task<List<Notification>> GetNotificationsByUserAsync(int userId);

        Task<int> GetUnreadCountAsync(int userId);

        Task CreateNotificationAsync(int userId,string title,string message, NotificationType type);
    }
}
