using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Interfaces
{
    public interface IReadOnlyDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}