using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> GetUserWithTasksAsync(int id);
        Task<List<User>> SearchUsersAsync(string keyword);

        Task<List<User>> GetAdminsAsync();

        Task<List<User>> FilterUsersAsync(string search, int? roleId, DataStatus? status);
    }
}
