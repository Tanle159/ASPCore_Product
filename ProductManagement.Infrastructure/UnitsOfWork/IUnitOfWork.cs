using Microsoft.EntityFrameworkCore;
using ProductManagement.Infrastructure.Repositories;
using ProductManagement.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        Task<bool> SaveChangeAsync();

        DbContext GetDbContext();

        IGenericRepository<T> Repository<T>() where T : class;

        IProductRepository GetProductRepository();
    }
}