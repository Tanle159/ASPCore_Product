using System;
using System.Collections.Generic;

namespace ProductManagement.Domain
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DiscontinuedDate { get; set; }

        public int Rating { get; set; }

        public double Price { get; set; }

        public int? SupplierID { get; set; }
        
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }
    }
}