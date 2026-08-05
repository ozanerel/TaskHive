using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Concretes
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        readonly MyContext _context;
        public UserRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAdminsAsync()
        {
            //return await _context.Users
            //    .Where(x => x.Role.Name == "Admin" && x.Status != DataStatus.Deleted)
            //    .ToListAsync();

            return await _context.Users
                .Include(x => x.Role)
                .Where(x => x.Role.Name == "Admin")
                .ToListAsync();
        }

        public async Task<User> GetUserWithTasksAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> SearchUsersAsync(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            return await _context.Users
                .Where(x =>
                    x.FirstName.Contains(keyword) ||
                    x.LastName.Contains(keyword) ||
                    x.Email.Contains(keyword))
                .OrderBy(x => x.FirstName)
                .Take(10)
                .ToListAsync();
        }
    }
}
