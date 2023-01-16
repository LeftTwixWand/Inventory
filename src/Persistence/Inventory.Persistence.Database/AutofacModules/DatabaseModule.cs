using Autofac;
using Inventory.Domain.Products;
using Inventory.Persistence.Database.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory.Persistence.Database.AutofacModules;

public sealed class DatabaseModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        _ = builder.Register(componentContext =>
        {
            ILoggerFactory loggerFactory = componentContext.Resolve<ILoggerFactory>();

            DbContextOptionsBuilder<DatabaseContext> builder = new();
            _ = builder.UseSqlite("Data Source=Database.db");
            _ = builder.UseLoggerFactory(loggerFactory);

            return builder.Options;
        });

        _ = builder.Register<DatabaseContext>(componentContext =>
        {
            DbContextOptions<DatabaseContext> options = componentContext.Resolve<DbContextOptions<DatabaseContext>>();
            return new(options);
        }).SingleInstance();

        _ = builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
    }
}