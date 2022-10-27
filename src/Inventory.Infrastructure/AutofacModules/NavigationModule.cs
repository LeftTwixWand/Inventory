using Autofac;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.ActivityLog;
using Inventory.Application.ViewModels.ContentGrid;
using Inventory.Application.ViewModels.Customers;
using Inventory.Application.ViewModels.Dashboard;
using Inventory.Application.ViewModels.DataGrid;
using Inventory.Application.ViewModels.ListDetails;
using Inventory.Application.ViewModels.Main;
using Inventory.Application.ViewModels.Orders;
using Inventory.Application.ViewModels.Product;
using Inventory.Application.ViewModels.Products;
using Inventory.Application.ViewModels.Settings;
using Inventory.Application.ViewModels.Shell;
using Inventory.Application.ViewModels.WebView;
using Inventory.Infrastructure.Services.Navigation;
using Inventory.Presentation.Views.Shell;
using Inventory.Presentation.Windows;
using Microsoft.UI.Xaml;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class NavigationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PageService>().As<IPageService>().SingleInstance();
        builder.RegisterType<NavigationViewService>().As<INavigationViewService>().SingleInstance();
        builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

        builder.RegisterType<MainWindow>().As<Window>().SingleInstance();
        builder.RegisterType<ShellView>().SingleInstance();

        builder.RegisterType<ShellViewModel>().InstancePerDependency();
        builder.RegisterType<DashboardViewModel>().InstancePerDependency();
        builder.RegisterType<CustomersViewModel>().InstancePerDependency();
        builder.RegisterType<OrdersViewModel>().InstancePerDependency();
        builder.RegisterType<ActivityLogViewModel>().InstancePerDependency();
        builder.RegisterType<MainViewModel>().InstancePerDependency();
        builder.RegisterType<SettingsViewModel>().InstancePerDependency();
        builder.RegisterType<DataGridViewModel>().InstancePerDependency();
        builder.RegisterType<ContentGridDetailViewModel>().InstancePerDependency();
        builder.RegisterType<ContentGridViewModel>().InstancePerDependency();
        builder.RegisterType<ListDetailsViewModel>().InstancePerDependency();
        builder.RegisterType<WebViewViewModel>().InstancePerDependency();
        builder.RegisterType<ProductsViewModel>().SingleInstance();
        builder.RegisterType<ProductViewModel>().InstancePerDependency();
    }
}