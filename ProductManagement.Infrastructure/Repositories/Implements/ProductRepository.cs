using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain;
using ProductManagement.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories.Implements
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext):base(dbContext)
        {

        }

        public async Task<bool> UpdatePrice(double price, int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                return false;
            item.Price = price;
            return true;
        }
    }
}
