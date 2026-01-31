using Microsoft.EntityFrameworkCore;
using MiniGroceryOrderSystem.Models;

namespace MiniGroceryOrderSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Rice", Price = 60, Stock = 50 },
                new Product { Id = 2, Name = "Milk", Price = 30, Stock = 40 },
                new Product { Id = 3, Name = "Bread", Price = 25, Stock = 30 }
            );
        }
    }
}
