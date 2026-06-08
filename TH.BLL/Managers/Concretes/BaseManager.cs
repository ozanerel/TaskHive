using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Interfaces;

namespace TH.BLL.Managers.Concretes
{
    public abstract class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        readonly IRepository<T> _repository;
        protected BaseManager(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = DataStatus.Inserted;

            await _repository.CreateAsync(entity);
        }

        public async Task<string> DeleteAsync(T entity)
        {
            if(entity == null)
            {
                return "Kayıt Bulunamadı";
            }
            if(entity.Status == DataStatus.Deleted)
            {
                return "Sadece pasif kayıtlar silinebilir";
            }
            var original = await _repository.GetByIdAsync(entity.Id);
            if(original == null)
            {
                return "Kayıt Bulunamadı";
            }
            await _repository.DeleteAsync(original);
            return "Kayıt Silindi";
        }

        public List<T> GetActives()
        {
            return _repository.Where(x => x.Status != DataStatus.Inserted || x.Status == DataStatus.Updated).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public List<T> GetModifieds()
        {
            return _repository.Where(x => x.Status == DataStatus.Updated).ToList();
        }

        public List<T> GetPassives()
        {
            return _repository.Where(x => x.Status == DataStatus.Deleted).ToList();
        }

        public async Task MakePassiveAsync(T entity)
        {
            if (entity == null) return;

            var original = await _repository.GetByIdAsync(entity.Id);
            if(original == null) return;

            original.DeletedDate = DateTime.Now;
            original.Status = DataStatus.Deleted;

            await _repository.UpdateAsync(original, original);
        }

        public async Task RestoreAsync(T entity)
        {
            if (entity == null) return;

            var original = await _repository.GetByIdAsync(entity.Id);
            if (original == null) return;

            original.DeletedDate = DateTime.Now;
            original.Status = DataStatus.Updated;
            await _repository.UpdateAsync(original, original);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.Status = DataStatus.Updated;
            T originalValue = await _repository.GetByIdAsync(entity.Id);
            if (originalValue == null) return;

            await _repository.UpdateAsync(originalValue, entity);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }
    }
}
