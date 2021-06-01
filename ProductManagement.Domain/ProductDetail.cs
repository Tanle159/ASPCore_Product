namespace ProductManagement.Domain
{
    public class ProductDetail
    {
        public int ProductID { get; set; }

        public string Details { get; set; }

        public virtual Product Product { get; set; }
    }
}