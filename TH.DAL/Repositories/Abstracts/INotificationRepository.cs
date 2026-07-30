using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface INotificationRepository:IRepository<Notification>
    {
        Task<List<Notification>> GetUnreadNotificationsAsync(int userId);

        Task<List<Notification>> GetNotificationsByUserAsync(int userId);

        Task<int> GetUnreadCountAsync(int userId);
    }
}
