using ProductManagement.Application.ProductsService.DTO;
using ProductManagement.Common.StatusActions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.ProductsService.Services
{
    public interface IProductServices
    {
        Task<StatusActionBase> AddProduct(ProductDTO productDTO);

        Task<StatusActionBase> DeleteProduct(int key);

        Task<StatusActionBase> GetAllProduct();

        Task<StatusActionBase> GetProductById(int id);

        Task<StatusActionBase> EditProductData(ProductDataUpdate productUpdated);

        Task<StatusActionBase> UpdatePrice(double? price, int id);

        Task<StatusActionBase> GetByQuery( string name, List<int>? categories, double? priceFrom, double? priceTo, int? page, int? size);
    }
}
