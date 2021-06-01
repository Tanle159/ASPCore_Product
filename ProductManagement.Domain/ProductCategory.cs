using System.Text.Json.Serialization;

namespace ProductManagement.Domain
{
    public class ProductCategory
    {
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}