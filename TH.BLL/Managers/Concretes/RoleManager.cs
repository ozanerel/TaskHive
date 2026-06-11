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
    public class RoleManager:BaseManager<Role>, IRoleManager
    {
        private readonly IRoleRepository _repository;

        public RoleManager(IRoleRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
