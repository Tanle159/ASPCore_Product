using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.BaseService;
using ProductManagement.Common.Errors;
using ProductManagement.Infrastructure.UnitsOfWork;
using ProductManagement.Persistences;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.BaseService
{
    public class BaseServices<TEntity, TModel> : IBaseServices<TEntity, TModel> where TEntity : class where TModel : class
    {
        protected readonly IServiceProvider _serviceProvider;

        protected readonly IMapper _mapper;

        public BaseServices(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public virtual async Task<TModel> CreateEntityAsync(TModel entity)
        {
            using (var unitOfWork = NewDbContext())
            {
                var repo = unitOfWork.Repository<TEntity>();

                var model = this._mapper.Map<TModel, TEntity>(entity);

                var result = await repo.InsertAsync(model);

                var check = await unitOfWork.SaveChangeAsync();

                if (check == false)
                {
                    throw new SaveChangeError();
                }

                return _mapper.Map<TEntity, TModel>(result);
            }
        }

        public virtual async Task<bool> DeleteAsync(object key)
        {
            using (var unitOfWork = NewDbContext())
            {
                var repo = unitOfWork.Repository<TEntity>();

                var result = await repo.DeleteAsync(key);
                if (result == false)
                    throw new NotFoundError();

                var check = await unitOfWork.SaveChangeAsync();

                if (check == false)
                {
                    throw new SaveChangeError();
                }
                return true;
            }
        }

        public virtual async Task<IEnumerable<TModel>> GetAllEntityAsync()
        {
            using (var unitOfWork = NewDbContext())
            {
                var repo = unitOfWork.Repository<TEntity>();

                var ds = await repo.GetAllAsync();

                return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(ds);
            }
        }

        public virtual async Task<TModel> GetById(object key)
        {
            try
            {
                using (var unitOfWork = NewDbContext())
                {
                    var repo = unitOfWork.Repository<TEntity>();

                    var result = await repo.GetByIdAsync(key);

                    return _mapper.Map<TEntity, TModel>(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TModel> GetFirstAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var unitOfWork = NewDbContext())
            {
                var repo = unitOfWork.Repository<TEntity>();

                return _mapper.Map<TEntity, TModel>(await repo.GetFirst(filter));
            }
        }

        public IUnitOfWork NewDbContext()
        {
            var newContext = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope()
                .ServiceProvider.GetRequiredService<ProductDataContext>();
            return new UnitsOfWork(newContext);
        }

        public virtual async Task<bool> UpdateEntityAsync(TModel entity, object key)
        {
            using (var unitOfWork = NewDbContext())
            {
                var repo = unitOfWork.Repository<TEntity>();

                var model = await repo.GetByIdAsync(key);

                if (model != null)
                {
                    model = _mapper.Map(entity, model);
                }

                repo.Update(model);

                var check = await unitOfWork.SaveChangeAsync();

                if (check == false)
                {
                    throw new SaveChangeError();
                }

                return true;
            }
        }
    }
}