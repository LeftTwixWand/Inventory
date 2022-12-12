using Inventory.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory.Persistence.Database;

internal sealed class DatabaseContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    // public DatabaseContext()
    // {
    //     // Required for migrations generation
    // }

    public DatabaseContext(DbContextOptions<DatabaseContext> options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    internal DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory);

        // Required for migrations generation
        // if (optionsBuilder.IsConfigured is false)
        // {
        //     var connectionStringBuilder = new SqliteConnectionStringBuilder()
        //     {
        //         DataSource = "Database.db",
        //     };

        // optionsBuilder.UseSqlite(connectionStringBuilder.ToString());
        // }
    }
}