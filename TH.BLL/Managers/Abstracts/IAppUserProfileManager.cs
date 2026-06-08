using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Abstracts
{
    public interface IAppUserProfileManager:IManager<AppUserProfile>
    {
        System.Threading.Tasks.Task UpdateProfilePhotoAsync(int profileId, string photoPath);
    }
}
