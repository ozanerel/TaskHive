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
    public class AppUserRepository:BaseRepository<AppUser>, IAppUserRepository
    {
        private readonly MyContext _context;
        public AppUserRepository(MyContext context):base(context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByUserNameAsync(string userName)
        {
            return await _context.AppUsers
               .FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<List<AppUser>> GetUserByRoleAsync(string roleName)
        {
            return await(from user in _context.AppUsers
                         join userRole in _context.UserRoles on user.Id equals userRole.UserId
                         join role in _context.Roles on userRole.RoleId equals role.Id
                         where role.Name == roleName
                         select user).ToListAsync();
        }
    }
}
