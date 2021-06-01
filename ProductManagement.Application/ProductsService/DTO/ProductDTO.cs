using ProductManagement.Application.ProductCategoryService.DTO;
using ProductManagement.Application.ProductDetailService.DTO;
using ProductManagement.Application.ProductsService.DTO;
using ProductManagement.Application.SupplierService.DTO;
using System;
using System.Collections.Generic;

namespace ProductManagement.Application.ProductsService.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DiscontinuedDate { get; set; }

        public int Rating { get; set; }

        public double Price { get; set; }

        public int? SupplierID { get; set; }

        public virtual ICollection<ProductCategoryDTO> ProductCategories { get; set; }

        public virtual ProductDetailDTO ProductDetail { get; set; }

    }
}