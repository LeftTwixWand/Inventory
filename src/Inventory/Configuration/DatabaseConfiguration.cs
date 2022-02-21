using System.IO;
using Inventory.Database;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Windows.Storage;

namespace Inventory.Configuration;

internal static class DatabaseConfiguration
{
    private const string DatabaseName = "Inventory.db";

    internal static DbContextOptions<DatabaseContext> GetOprions()
    {
        var builder = new DbContextOptionsBuilder<DatabaseContext>();

        builder.UseSqlite(GetConnectionString());

        return builder.Options;
    }

    private static string GetConnectionString()
    {
        var fullPath = Path.Combine(GetDatabaseLocation(), DatabaseName);

        return new SqliteConnectionStringBuilder()
        {
            DataSource = fullPath,
        }
        .ToString();
    }

    private static string GetDatabaseLocation()
    {
        return ApplicationData.Current.LocalFolder.Path;
    }
}