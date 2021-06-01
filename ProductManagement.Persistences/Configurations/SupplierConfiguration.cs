using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain;

namespace ProductManagement.Persistences.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> x)
        {
            x.ToTable("Suppliers");

            x.HasKey(i => i.ID);

            x.Property(x => x.ID).ValueGeneratedOnAdd();
        }
    }
}