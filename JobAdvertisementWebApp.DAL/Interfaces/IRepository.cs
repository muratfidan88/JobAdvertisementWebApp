using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobAdvertisementWebApp.DAL.Interfaces
{
    public interface IRepository<T> where T: class, new()
    {
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
        void Delete(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllFilterAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
