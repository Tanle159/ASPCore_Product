using ProductManagement.Application.ProductDetailService.DTO;
using System;
using System.Collections.Generic;

namespace ProductManagement.Application.ProductsService.DTO
{
    public class ProductDataUpdate
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DiscontinuedDate { get; set; }

        public int Rating { get; set; }

        public double Price { get; set; }

        public ICollection<int> CategoryIds { get; set; }

        public int? SupplierID { get; set; }

        public string Detail { get; set; }

    }
}
