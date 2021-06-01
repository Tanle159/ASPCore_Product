using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain;
using ProductManagement.Persistences.Configurations;
using System;

namespace ProductManagement.Persistences
{
    public class ProductDataContext : IdentityDbContext<User, Role, Guid>
    {
      
        // Khai bao cac class Domain tuong ung voi DBSet
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductDetail> ProductDetails { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        public ProductDataContext(DbContextOptions<ProductDataContext> options) : base(options)
        {
        }

        /// <summary>
        ///  Can tach ra moi class config
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());

            
        }
    }
}