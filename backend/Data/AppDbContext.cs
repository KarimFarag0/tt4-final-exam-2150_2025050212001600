using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Contact> Contacts { get; set; }

        // Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add sample contacts
            modelBuilder.Entity<Contact>().HasData(
                new Contact { ID = 1, FullName = "John Doe", Email = "john.doe@example.com", Phone = "123-456-7890" },
                new Contact { ID = 2, FullName = "Jane Smith", Email = "jane.smith@example.com", Phone = "234-567-8901" },
                new Contact { ID = 3, FullName = "Alice Johnson", Email = "alice.johnson@example.com", Phone = "345-678-9012" }
            );
        }
    }
}