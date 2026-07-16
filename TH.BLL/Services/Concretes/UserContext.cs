using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TH.BLL.Services.Abstracts;
using TH.DAL.ContextClasses;
using TH.ENTITIES.Models;

namespace TH.BLL.Services.Concretes
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly MyContext _context;


        public UserContext
        (
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            MyContext context
        )
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
        }


        public async Task<User> GetCurrentUserAsync()
        {
            var userName =
                _httpContextAccessor
                .HttpContext?
                .User?
                .Identity?
                .Name;


            if (string.IsNullOrEmpty(userName))
                return null;


            AppUser appUser =
                await _userManager.FindByNameAsync(userName);


            if (appUser == null)
                return null;


            //User user =
            //    await _context.Users
            //    .Include(x => x.Role)
            //    .
            //    .FirstOrDefaultAsync(x => x.AppUserId == appUser.Id);

            User user =
                await _context.Users
                .Include(x => x.Role)
                .Include(x => x.AppUser)
                .ThenInclude(x => x.AppUserProfile)
                .Include(x => x.Tasks)
                .Include(x => x.Projects)
                .Include(x => x.Notifications)
                .FirstOrDefaultAsync(x => x.AppUserId == appUser.Id);


            return user;
        }
    }
}