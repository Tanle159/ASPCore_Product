using ProductManagement.Application.CategoryService.DTO;
using ProductManagement.Application.ProductDetailService.DTO;
using ProductManagement.Application.SupplierService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement.Application.ProductsService.DTO
{
    public class ProductView
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DiscontinuedDate { get; set; }

        public int Rating { get; set; }

        public double Price { get; set; }

        public ICollection<CategoryDTO> categories { get; set; }

        public virtual SupplierDTO Supplier { get; set; }

        public virtual ProductDetailDTO ProductDetail { get; set; }
    }
}
