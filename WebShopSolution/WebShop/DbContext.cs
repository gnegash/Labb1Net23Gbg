using Microsoft.EntityFrameworkCore;
using WebShop.Entities;

namespace WebShop
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for Products
        public DbSet<Product> Products { get; set; }

        // Optional: OnModelCreating for custom configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Additional configurations for Product (if needed)
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
        }
    }

}
