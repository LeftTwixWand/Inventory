using Autofac;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DataStorage;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;
using Inventory.Database.Domain.UnitOfWorks.DataStorage;
using Inventory.Database.Domain.UnitOfWorks.DomainEventsDispatching;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Database.AutofacModules;

public sealed class DatabaseModule : Module
{
    private const string DatabaseName = "Inventory.db";

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseContext>().WithParameter("options", GetOptions()).InstancePerDependency();

        builder.RegisterType<DomainEventsProvider>().As<IDomainEventsProvider>().InstancePerLifetimeScope();
        builder.RegisterType<DataStorage>().As<IDataStorage>().InstancePerLifetimeScope();
    }

    private static DbContextOptions<DatabaseContext> GetOptions()
    {
        var builder = new DbContextOptionsBuilder<DatabaseContext>();

        builder.UseSqlite(GetConnectionString());

        return builder.Options;
    }

    private static string GetConnectionString()
    {
        var connectionStringBuilder = new SqliteConnectionStringBuilder()
        {
            DataSource = DatabaseName,
        };

        return connectionStringBuilder.ToString();
    }
}