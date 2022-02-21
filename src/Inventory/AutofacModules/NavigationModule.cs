using Autofac;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.MainViewModels;
using Inventory.Application.ViewModels.ProductsViewModels;
using Inventory.Application.ViewModels.ProductViewModels;
using Microsoft.UI.Xaml;

namespace Inventory.AutofacModules;

internal class NavigationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var window = (Microsoft.UI.Xaml.Application.Current as App)?.Window;
        if (window is not null)
        {
            builder.RegisterInstance(window).As<Window>();
        }

        builder.RegisterType<NavigationService>().As<INavigationService>().InstancePerLifetimeScope();

        builder.RegisterType<MainViewModel>().InstancePerDependency();
        builder.RegisterType<ProductsViewModel>().InstancePerDependency();
        builder.RegisterType<ProductViewModel>().InstancePerDependency();
    }
}