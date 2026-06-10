using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class AppUserProfileManager : BaseManager<AppUserProfile>, IAppUserProfileManager
    {
        private readonly IAppUserProfileRepository _repository;
        public AppUserProfileManager(IAppUserProfileRepository repository): base(repository)
        {
            _repository = repository;
        }
        public async System.Threading.Tasks.Task UpdateProfilePhotoAsync(int profileId, string photoPath)
        {
            var profile = await _repository.GetByIdAsync(profileId);
            if (profile == null) return;

            profile.ImageUrl = photoPath;
            profile.UpdatedDate = DateTime.Now;
            await _repository.UpdateAsync(profile, profile);
        }
    }
}
