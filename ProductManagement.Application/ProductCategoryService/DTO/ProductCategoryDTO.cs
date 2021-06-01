using ProductManagement.Application.CategoryService.DTO;
using ProductManagement.Application.ProductsService.DTO;
using System.Text.Json.Serialization;

namespace ProductManagement.Application.ProductCategoryService.DTO
{
    public class ProductCategoryDTO
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

    }
}