using Inventory.Domain.Categories;
using Inventory.Domain.Products;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
    }

    internal DbSet<Category> Categories => Set<Category>();

    internal DbSet<Product> Products => Set<Product>();

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }
}