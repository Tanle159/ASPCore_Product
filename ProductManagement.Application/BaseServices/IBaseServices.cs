using ProductManagement.Infrastructure.UnitsOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Application.BaseService
{
    public interface IBaseServices<TEntity, TModel> where TEntity : class where TModel : class
    {
        IUnitOfWork NewDbContext();

        Task<IEnumerable<TModel>> GetAllEntityAsync();

        Task<TModel> CreateEntityAsync(TModel entity);

        Task<bool> UpdateEntityAsync(TModel entity, object key);

        Task<bool> DeleteAsync(object key);

        Task<TModel> GetById(object key);
    }
}