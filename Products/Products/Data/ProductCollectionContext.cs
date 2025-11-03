using Microsoft.EntityFrameworkCore;
using ProductCollection.Model;

namespace ProductCollection.Data
{
    public class ProductCollectionContext : DbContext
    {
        public ProductCollectionContext (DbContextOptions<ProductCollectionContext> options)
            : base(options)
        {
        }

        public ProductCollectionContext()
        {
            
        }

        public DbSet<Product> Products { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProductCollection"));
        }
    }
}
