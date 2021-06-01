using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext dbContext;
        protected DbSet<T> entities;

        public GenericRepository(DbContext dbContext)
        {
            this.entities = dbContext.Set<T>();
            this.dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(object key)
        {
            var entity = await GetByIdAsync(key);
            if (entity != null)
            {
                if (this.entities.Remove(entity) != null)
                    return true;
            };
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object key)
        {
            return await this.entities.FindAsync(key);
        }

        public IQueryable<T> GetByQuery()
        {
            return this.entities.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.entities.Where(filter).ToListAsync();
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> filter)
        {
            return await this.entities.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            await this.entities.AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}