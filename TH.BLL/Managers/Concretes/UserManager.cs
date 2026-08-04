using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Concretes
{
    public class UserManager : BaseManager<User>, IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly INotificationManager _notificationManager;

        public UserManager(IUserRepository repository, INotificationManager notificationManager)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
        }

        public override async Task CreateAsync(User user)
        {
            await base.CreateAsync(user);

            await _notificationManager.CreateNotificationAsync(
                user.Id,
                "Welcome",
                $"Welcome {user.FirstName}!",NotificationType.Welcome
            );
        }

        public async Task<User> GetUserWithTasksAsync(int userId)
        {
            return await _repository.GetUserWithTasksAsync(userId);
        }

        public async Task<List<ENTITIES.Models.Task>> GetAssignedTasksAsync(int userId)
        {
            var user = await _repository.GetUserWithTasksAsync(userId);

            if (user == null)
                return new List<ENTITIES.Models.Task>();

            return user.Tasks.ToList();
        }

        public async Task<List<User>> GetAdminsAsync()
        {
            return await _repository.GetAdminsAsync();
        }
    }
}
