using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        //sätt upp databas codefirst dotnet ef + migration
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // konfig relationer eller restriktioner

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id); // Define primary key
                entity.Property(p => p.Name)
                      .IsRequired() // Mark Name as required
                      .HasMaxLength(100); // Limit Name to 100 characters
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
