using Geschäft.Domain.ProductAgg;
using Geschäft.Domain.ProductCategoryAgg;
using Geschäft.Infrastracture.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Geschäft.Infrastracture.EFCore
{
    public class GeschäftContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public GeschäftContext(DbContextOptions<GeschäftContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
