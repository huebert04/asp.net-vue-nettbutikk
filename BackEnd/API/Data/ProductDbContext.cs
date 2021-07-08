using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {}

        public DbSet<ProductEntity> ProductSet { get; set; }
    }
}