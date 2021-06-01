using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> InsertAsync(T entity);

        T Update(T entity);

        Task<bool> DeleteAsync(object key);

        Task<T> GetByIdAsync(object key);

        IQueryable<T> GetByQuery();

        Task<IEnumerable<T>> GetFilterAsync(Expression<Func<T, bool>> filter);

        Task<T> GetFirst(Expression<Func<T, bool>> filter);
    }
}