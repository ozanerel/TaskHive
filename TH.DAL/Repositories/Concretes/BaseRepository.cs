using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TH.DAL.ContextClasses;
using TH.DAL.Repositories.Abstracts;

namespace TH.DAL.Repositories.Concretes
{
    public abstract class BaseRepository<T>:IRepository<T> where T : class
    {
        readonly MyContext _context;
        readonly DbSet<T> _dbSet;//EF Core'un veritabanındaki tabloyu temsil eden sınıfıdır.
        public BaseRepository(MyContext context)
        {
            //Ef Core üzerinden veritabanına erişimi soyutlar.Her entity için aynı CRUD işlemlerini tekrar yazmamıza gerek kalmıyor bu sayede.
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task CraeteAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async void DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async void UpdateAsync(T originalEntity,T newEntity)
        {
            _dbSet.Entry(originalEntity).CurrentValues.SetValues(newEntity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _dbSet.Where(exp);
        }
    }
}
