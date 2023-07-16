using Inventory.Domain.Orders;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Database;

internal sealed class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    internal DbSet<Product> Products => Set<Product>();

    internal DbSet<Warehouse> Warehouses => Set<Warehouse>();

    internal DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder()
            {
                DataSource = "Database.db",
            };

            optionsBuilder.UseSqlite(connectionStringBuilder.ToString());
        }
    }
}