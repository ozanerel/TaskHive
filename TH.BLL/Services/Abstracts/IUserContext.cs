using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Services.Abstracts
{
    public interface IUserContext
    {
        Task<User> GetCurrentUserAsync();
    }
}
