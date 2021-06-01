using System.Collections.Generic;

namespace ProductManagement.Application.ProductsService.DTO
{
    public class ProductInfoFilter
    {
        public string Name { get; set; }

        public List<int> Categories { get; set; }

        public int? Page { get; set; }

        public int? Size { get; set; }

        public double? PriceFrom { get; set; }

        public double? PriceTo { get; set; }
    }
}
