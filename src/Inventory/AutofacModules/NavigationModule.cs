using Autofac;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.MainViewModels;
using Inventory.Application.ViewModels.ProductsViewModels;

namespace Inventory.AutofacModules;

internal class NavigationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<NavigationService>().As<INavigationService>().InstancePerLifetimeScope();

        builder.RegisterType<MainViewModel>().InstancePerDependency();
        builder.RegisterType<ProductsViewModel>().InstancePerDependency();
    }
}