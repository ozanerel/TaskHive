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
using Task = System.Threading.Tasks.Task;
using TH.BLL.Helpers;

namespace TH.BLL.Managers.Concretes
{
    public class UserManager : BaseManager<User>, IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly INotificationManager _notificationManager;
        private readonly ITeamMemberRepository _teamMemberRepository;

        public UserManager(IUserRepository repository, INotificationManager notificationManager,ITeamMemberRepository teamMemberRepository)
            : base(repository)
        {
            _repository = repository;
            _notificationManager = notificationManager;
            _teamMemberRepository = teamMemberRepository;
        }

        public override async Task CreateAsync(User user)
        {
            string userTag;

            do
            {
                userTag = UserTagGenerator.Generate();
            }
            while (await _repository.UserTagExistsAsync(userTag));

            //Yeni kullanıcı oluşturulduğunda UserTag otomatik alacak
            user.UserTag = UserTagGenerator.Generate();

            await base.CreateAsync(user);

            await _notificationManager.CreateNotificationAsync(
                user.Id,
                "Welcome",
                $"Welcome {user.FirstName}!",NotificationType.Welcome
            );
        }

        public override async Task UpdateAsync(User user)
        {
            var oldUser = await _repository.GetByIdAsync(user.Id);

            if (oldUser == null)
                return;


            bool roleChanged = oldUser.RoleId != user.RoleId;


            await base.UpdateAsync(user);


            if (roleChanged)
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "Role Updated",
                    $"Your role has been changed.",
                    NotificationType.UserUpdated
                );
            }
            else
            {
                await _notificationManager.CreateNotificationAsync(
                    user.Id,
                    "Profile Updated",
                    "Your profile information has been updated.",
                    NotificationType.UserUpdated
                );
            }
        }

        public override async Task MakePassiveAsync(User user)
        {
            var userWithDetails = await _repository.GetByIdAsync(user.Id);

            if (userWithDetails == null)
                return;


            await base.MakePassiveAsync(userWithDetails);


            var admins = await GetAdminsAsync();


            foreach (var admin in admins)
            {
                await _notificationManager.CreateNotificationAsync(
                    admin.Id,
                    "User Deleted",
                    $"User \"{userWithDetails.FirstName} {userWithDetails.LastName}\" has been deleted.",
                    NotificationType.UserDeleted
                );
            }
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

        public async Task<List<User>> FilterUsersAsync(string search, int? roleId, DataStatus? status)
        {
            return await _repository.FilterUsersAsync(search,roleId,status);
        }

        public async Task<User> GetByAppUserIdAsync(int appUserId)
        {
            return await _repository.GetByAppUserIdAsync(appUserId);
        }

        public async Task<List<User>> GetAvailableUsersForTeamAsync(int teamId)
        {
            var users = await _repository
            .GetAllAsync();

            var teamMemberIds = await _teamMemberRepository
                .GetTeamMemberUserIdsAsync(teamId);

            return users
                .Where(x =>
                    x.Status != DataStatus.Deleted &&
                    !teamMemberIds.Contains(x.Id))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
        }
    }
}
