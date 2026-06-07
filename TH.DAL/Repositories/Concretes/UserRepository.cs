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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        readonly MyContext _context;
        public UserRepository(MyContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> GetUserWithTasksAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
