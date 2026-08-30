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

        public async Task<List<User>> FilterUsersAsync(string search,int? roleId,DataStatus? status)
        {
            var query = _context.Users
                .Include(x => x.Role)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                query = query.Where(x =>
                    x.FirstName.ToLower().Contains(search) ||
                    x.LastName.ToLower().Contains(search) ||
                    x.Email.ToLower().Contains(search));
            }


            if (roleId.HasValue)
            {
                query = query.Where(x => x.RoleId == roleId);
            }


            if (status.HasValue)
            {
                query = query.Where(x => x.Status == status);
            }


            return await query.ToListAsync();
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

        public async Task<User> GetByAppUserIdAsync(int appUserId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.AppUserId == appUserId);
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
                .Where(x =>x.FirstName.ToLower().Contains(keyword) || x.LastName.ToLower().Contains(keyword) ||x.Email.ToLower().Contains(keyword))
                .OrderBy(x => x.FirstName)
                .Take(10)
                .ToListAsync();
        }

        public async Task<bool> UserTagExistsAsync(string userTag)
        {
            return await _context.Users
                .AnyAsync(x => x.UserTag == userTag);
        }
    }
}
