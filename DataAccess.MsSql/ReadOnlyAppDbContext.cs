using Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MsSql
{
    public class ReadOnlyAppDbContext : DbContext, IReadOnlyDbContext
    {
        public ReadOnlyAppDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().HasKey(o => new {o.OrderId, o.ProductId});

            modelBuilder.Entity<Product>().HasData(
                new Product {Id = 1, Name = "Milk", Price = 100},
                new Product {Id = 2, Name = "Cola", Price = 200});
        }
    }
}