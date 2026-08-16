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
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public AppUserManager(IAppUserRepository repository,UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager) : base(repository)
        {
            _repository = repository;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async System.Threading.Tasks.Task ChangeUserRoleAsync(int userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!await _roleManager.RoleExistsAsync(newRole))
                await _roleManager.CreateAsync(new IdentityRole<int>(newRole));

            await _userManager.AddToRoleAsync(user, newRole);

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

            //Rol yoksa oluştur
            if (!await _roleManager.RoleExistsAsync(rolename))
                await _roleManager.CreateAsync(new IdentityRole<int>(rolename));

            // Role ekle
            await _userManager.AddToRoleAsync(newUser, rolename);

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

        public async Task<List<AppUser>> GetUsersByRoleAsync(string roleName)
        {
            return await _repository.GetUserByRoleAsync(roleName);
        }

        public async Task<AppUser> RegisterAsync(string username, string firstName, string lastName, string email, string password)
        {
            //==============================================
            // 1. Username kontrolü
            //==============================================

            var existingUser =
                await _userManager.FindByNameAsync(username);

            if (existingUser != null)
            {
                throw new Exception(
                    "Bu kullanıcı adı zaten mevcut.");
            }


            //==============================================
            // 2. Email kontrolü
            //==============================================

            var existingEmail =
                await _userManager.FindByEmailAsync(email);

            if (existingEmail != null)
            {
                throw new Exception(
                    "Bu email zaten kayıtlı.");
            }


            //==============================================
            // 3. AppUser oluştur
            //==============================================

            var newUser = new AppUser
            {
                UserName = username,
                Email = email,

                CreatedDate = DateTime.Now,

                SecurityStamp =
                    Guid.NewGuid().ToString(),

                ActivationCode = Guid.NewGuid(),

                Status = DataStatus.Inserted,

                EmailConfirmed = true
            };


            //==============================================
            // 4. Identity kullanıcı oluştur
            //==============================================

            var createResult =
                await _userManager.CreateAsync(
                    newUser,
                    password);

            if (!createResult.Succeeded)
            {
                var errors = string.Join(
                    " | ",
                    createResult.Errors
                        .Select(e => e.Description));

                throw new Exception(
                    "Kullanıcı oluşturulamadı: " + errors);
            }


            //==============================================
            // 5. Member Identity Role kontrolü
            //==============================================

            const string memberRole = "Member";

            if (!await _roleManager.RoleExistsAsync(memberRole))
            {
                var roleResult =
                    await _roleManager.CreateAsync(
                        new IdentityRole<int>(memberRole));

                if (!roleResult.Succeeded)
                {
                    // AppUser oluşturuldu fakat rol oluşturulamadı.
                    // Kullanıcıyı geri siliyoruz.
                    await _userManager.DeleteAsync(newUser);

                    var errors = string.Join(
                        " | ",
                        roleResult.Errors
                            .Select(e => e.Description));

                    throw new Exception(
                        "Member rolü oluşturulamadı: " + errors);
                }
            }


            //==============================================
            // 6. Member rolünü kullanıcıya ata
            //==============================================

            var addRoleResult =
                await _userManager.AddToRoleAsync(
                    newUser,
                    memberRole);

            if (!addRoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(newUser);

                var errors = string.Join(
                    " | ",
                    addRoleResult.Errors
                        .Select(e => e.Description));

                throw new Exception(
                    "Kullanıcı rolü atanamadı: " + errors);
            }


            //==============================================
            // 7. TaskHive User kaydı
            //==============================================

            // Burada User entity'sinin RoleId'sini
            // bulmamız gerekiyor.
            //
            // Bu nedenle Role tablosundan Member rolünü
            // alıyoruz.

            // NOT:
            // IdentityRole<int> ile TH.ENTITIES.Models.Role
            // birbirinden farklı tablolardır.

            throw new NotImplementedException();
        }
    }
}
