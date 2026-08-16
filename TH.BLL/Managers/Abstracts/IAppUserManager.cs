using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;
using Task = System.Threading.Tasks.Task;

namespace TH.BLL.Managers.Abstracts
{
    public interface IAppUserManager: IManager<AppUser>
    {
        //Admin için yeni kullanıcı oluşturma ve rol atama
        Task<AppUser> CreateUserWithRoleAsync(string username, string email, string password, string rolename);
        //Public register işlemi
        Task<AppUser> RegisterAsync(string username,string firstName,string lastName,string email,string password);
        //Kullanıcı adı ile kullanıcıyı getirme
        Task<List<AppUser>> GetUsersByRoleAsync(string roleName);
        //Kullanıcı rolünü değiştirme
        Task ChangeUserRoleAsync(int userId, string newRole);
        //Kullanıcıyı silme(identity tablosundan)
        Task DeleteUserAsync(int userId);
    }
}
