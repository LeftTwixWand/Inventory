using Autofac;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.DashboardViewModels;
using Inventory.Application.ViewModels.MainViewModels;
using Inventory.Application.ViewModels.ProductsViewModels;
using Inventory.Application.ViewModels.ProductViewModels;
using Inventory.Application.ViewModels.SettingsViewModels;
using Inventory.Configurations.Navigation;
using Inventory.Presentation.Views.MainViews;
using Inventory.Services.Navigation;
using Microsoft.UI.Xaml;

namespace Inventory.AutofacModules;

internal class NavigationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance(App.MainWindow).As<Window>();

        builder.RegisterType<ViewsService>().As<IViewsService>().InstancePerLifetimeScope();
        builder.RegisterType<NavigationViewService>().As<INavigationViewService>().InstancePerLifetimeScope();
        builder.RegisterType<NavigationService>().As<INavigationService>().InstancePerLifetimeScope();

        builder.RegisterType<MainViewModel>().InstancePerDependency();
        builder.RegisterType<MainView>().InstancePerDependency();

        builder.RegisterType<DashboardViewModel>().InstancePerDependency();
        //builder.RegisterType<DashboardView>().InstancePerDependency();

        builder.RegisterType<ProductsViewModel>().InstancePerDependency();
        builder.RegisterType<ProductViewModel>().InstancePerDependency();
        builder.RegisterType<SettingsViewModel>().InstancePerDependency();
    }
}