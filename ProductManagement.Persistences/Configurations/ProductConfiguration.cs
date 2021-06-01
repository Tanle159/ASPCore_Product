using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain;

namespace ProductManagement.Persistences.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> x)
        {
            x.ToTable("Products");
            // Xac dinh Primary Key
            x.HasKey(i => i.ID);
            // Set thuoc tinh tu tang dan cho Key
            x.Property(x => x.ID).ValueGeneratedOnAdd();
            // Rang buoc quan he
            //x.HasOne<ProductDetail>(i => i.ProductDetail).WithOne(x => x.Product).HasForeignKey<ProductDetail>(x => x.ProductID).IsRequired(false);

            x.HasOne<Supplier>(i => i.Supplier);   // *
        }
    }
}                               