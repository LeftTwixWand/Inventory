using Autofac;
using BuildingBlocks.Application.Services.DatabaseMigration;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DataStorage;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;
using Inventory.Database.Domain.Products;
using Inventory.Database.Domain.UnitOfWorks.DataStorage;
using Inventory.Database.Domain.UnitOfWorks.DomainEventsDispatching;
using Inventory.Database.Services.DatabaseMigration;
using Inventory.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Database.AutofacModules;

public sealed class DatabaseModule : Module
{
    private readonly DbContextOptions<DatabaseContext> _dbContextOptions;

    public DatabaseModule(DbContextOptions<DatabaseContext> dbContextOptions)
    {
        _dbContextOptions = dbContextOptions;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseContext>().WithParameter("options", _dbContextOptions).InstancePerDependency();

        builder.RegisterType<DomainEventsProvider>().As<IDomainEventsProvider>().InstancePerLifetimeScope();
        builder.RegisterType<DatabaseMigrationService>().As<IDatabaseMigrationService>().InstancePerLifetimeScope();
        builder.RegisterType<DataStorage>().As<IDataStorage>().InstancePerLifetimeScope();

        builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
    }
}