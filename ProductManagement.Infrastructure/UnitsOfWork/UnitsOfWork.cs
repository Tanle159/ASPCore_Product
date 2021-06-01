using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProductManagement.Common.Errors;
using ProductManagement.Domain;
using ProductManagement.Infrastructure.Repositories;
using ProductManagement.Infrastructure.Repositories.Implements;
using ProductManagement.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.UnitsOfWork
{
    public class UnitsOfWork : IUnitOfWork
    {
        protected DbContext dbContext;

        private bool disposed;

        /// <summary>
        /// dictionary to manage DI of repository
        /// </summary>
        private Dictionary<Type, object> repositories;

        /// <summary>
        /// manage scope of transaction
        /// </summary>
        private IDbContextTransaction transactionScope;

        public UnitsOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public void BeginTransaction()
        {
            if (this.transactionScope == null)
            {
                this.transactionScope = this.dbContext.Database.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            if (this.transactionScope != null)
            {
                this.transactionScope.Commit();
                this.transactionScope.Dispose();
                this.transactionScope = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (repositories != null)
                    {
                        this.repositories.Clear();
                        this.repositories = null;
                    }

                    if (transactionScope != null)
                    {
                        this.transactionScope.Commit();
                        this.transactionScope.Dispose();
                        this.transactionScope = null;
                    }
                    if (this.dbContext != null)
                    {
                        this.dbContext.Dispose();
                        this.dbContext = null;
                    }
                }
            }
            this.disposed = true;
        }

        public DbContext GetDbContext()
        {
            return this.dbContext;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            IGenericRepository<T> repository = null;

            if (this.repositories.ContainsKey(typeof(T)))
            {
                return this.repositories[typeof(T)] as IGenericRepository<T>;
            }
            else
            {
                repository = new GenericRepository<T>(this.dbContext);
                this.repositories.Add(typeof(T), repository);
            }
            return repository;
        }

        public void RollbackTransaction()
        {
            if (this.transactionScope != null)
            {
                this.transactionScope.Rollback();
                this.transactionScope.Dispose();
                this.transactionScope = null;
            }
        }

        public async Task<bool> SaveChangeAsync()
        {
            try
            {
                return (await this.dbContext.SaveChangesAsync()) > 0;
            }
            catch (Exception)
            {
                throw new SaveChangeError();
            }
        }

        public IProductRepository GetProductRepository()
        {
            IProductRepository repository = null;
            if (this.repositories.ContainsKey(typeof(Product)))
            {
                return this.repositories[typeof(Product)] as IProductRepository;
            }
            else
            {
                repository = new ProductRepository(this.dbContext);
                this.repositories.Add(typeof(Product), repository);
            }
            return repository;
        }
    }
}