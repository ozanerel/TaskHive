using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class UserManager : BaseManager<User>, IUserManager
    {
        private readonly IUserRepository _repository;

        public UserManager(IUserRepository repository)
            : base(repository)
        {
            _repository = repository;
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
    }
}
