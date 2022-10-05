using Autofac;
using Inventory.Domain.Products;
using Inventory.Persistence.Database.Domain.Products;

namespace Inventory.Persistence.Database.AutofacModules;

public sealed class DatabaseModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerLifetimeScope();
    }
}