using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.Repositories.Abstracts;
using TH.BLL.Managers.Abstracts;
using TH.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using TH.ENTITIES.Enums;

namespace TH.BLL.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUser>, IAppUserManager
    {
        private readonly IAppUserRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        public AppUserManager(IAppUserRepository repository,UserManager<AppUser> userManager):base(repository)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public async System.Threading.Tasks.Task ChangeUserRoleAsync(int userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) 
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            
        }

        public async Task<AppUser> CreateUserWithRoleAsync(string username, string email, string password, string rolename)
        {
            // Kullanıcı var mı kontrolü
            var existingUser = await _userManager.FindByNameAsync(username);
            if(existingUser != null)
            {
                throw new Exception("Bu kullanıcı adı zaten mevcut.");
            }

            //Email kontrolü
            var existingEmail = await _userManager.FindByEmailAsync(email);

            if (existingEmail != null)
                throw new Exception("Bu email zaten kayıtlı.");

            //Yeni user oluştur
            var newUser = new AppUser
            {
                UserName = username,
                Email = email,
                CreatedDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                Status = DataStatus.Inserted,
                EmailConfirmed = true
            };

            var createResult = await _userManager.CreateAsync(newUser, password);
            if (!createResult.Succeeded)
            {
                var errors = string.Join(" | ", createResult.Errors.Select(e => e.Description));
                throw new Exception("Kullanıcı oluşturulamadı: " + errors);
            }

            return newUser;


        }

        public async System.Threading.Tasks.Task DeleteUserAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            user.Status = DataStatus.Deleted;
            user.UpdatedDate = DateTime.Now;

            await _userManager.UpdateAsync(user);
        }

        public Task<List<AppUser>> GetUsersByRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
