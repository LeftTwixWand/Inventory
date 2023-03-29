using Autofac;
using Inventory.Domain.Products;
using Inventory.Persistence.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory.Persistence.Database.AutofacModules;

public sealed class DatabaseModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(componentContext =>
        {
            ILoggerFactory loggerFactory = componentContext.Resolve<ILoggerFactory>();

            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseSqlite("Data Source=Database.db");
            builder.UseLoggerFactory(loggerFactory);

            return builder.Options;
        });

        builder.Register<DatabaseContext>(componentContext =>
        {
            DbContextOptions<DatabaseContext> options = componentContext.Resolve<DbContextOptions<DatabaseContext>>();
            return new(options);
        }).SingleInstance();

        builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
    }
}