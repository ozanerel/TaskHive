using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Interfaces;

namespace TH.DAL.Repositories.Abstracts
{
    public interface IRepository<T> where T : class,IEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        /*Bu, veritabanı sorgusunu temsil eden bir nesnedir.Gerçek veriyi hemen getirmez sadece “hangi sorgunun çalıştırılacağını” tanımlar.Örnek olarak tüm userları getir değil,belirli bir project'deki userları getir gibi koşullu sorgular çalıştırmak için kullanılır.Kod generic hale gelir (her entity için kullanılabilir)
        */
        //Commands
        Task CreateAsync(T entity);
        Task UpdateAsync(T originalEntity,T newEntity);
        Task DeleteAsync(T entity);
    }
}
