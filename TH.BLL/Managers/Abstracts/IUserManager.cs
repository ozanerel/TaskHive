using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface IUserManager:IManager<User>
    {
        Task<User> GetUserWithTasksAsync(int userId);

        Task<List<ENTITIES.Models.Task>> GetAssignedTasksAsync(int userId);

        Task<List<User>> GetAdminsAsync();

        Task<List<User>> FilterUsersAsync(string search,int? roleId,DataStatus? status);

        Task<User> GetByAppUserIdAsync(int appUserId);
    }
}
