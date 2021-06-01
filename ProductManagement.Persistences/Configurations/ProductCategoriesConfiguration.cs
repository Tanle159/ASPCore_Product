

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain;

namespace ProductManagement.Persistences.Configurations
{
    public class ProductCategoriesConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> x)
        {
            x.ToTable("ProductCategories");
            x.HasKey(i => new { i.ProductID, i.CategoryID });

            x.HasOne<Product>(i => i.Product).WithMany(x => x.ProductCategories).HasForeignKey(j => j.ProductID).OnDelete(DeleteBehavior.Cascade);

            x.HasOne<Category>(i => i.Category).WithMany(x => x.ProductCategories).HasForeignKey(j => j.CategoryID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
