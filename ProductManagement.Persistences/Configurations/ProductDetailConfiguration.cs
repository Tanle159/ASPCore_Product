using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain;

namespace ProductManagement.Persistences.Configurations
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(i => i.ProductID);

            builder.HasOne<Product>(i => i.Product).WithOne(x => x.ProductDetail).HasForeignKey<ProductDetail>(x => x.ProductID).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        }
    }
}