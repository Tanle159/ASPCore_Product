using ProductManagement.Domain;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> UpdatePrice(double price, int id);
    }
}
