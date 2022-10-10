using Autofac;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.ContentGrid;
using Inventory.Application.ViewModels.DataGrid;
using Inventory.Application.ViewModels.ListDetails;
using Inventory.Application.ViewModels.Main;
using Inventory.Application.ViewModels.Settings;
using Inventory.Application.ViewModels.Shell;
using Inventory.Application.ViewModels.WebView;
using Inventory.Infrastructure.Services.Navigation;
using Inventory.Presentation.Views;
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

        builder.RegisterType<MainWindow>().As<Window>().InstancePerDependency();

        builder.RegisterType<ShellViewModel>().InstancePerDependency();
        builder.RegisterType<ShellView>().InstancePerDependency();

        builder.RegisterType<MainViewModel>().InstancePerDependency();
        builder.RegisterType<MainPage>().InstancePerDependency();

        builder.RegisterType<SettingsViewModel>().InstancePerDependency();
        builder.RegisterType<SettingsPage>().InstancePerDependency();

        builder.RegisterType<DataGridViewModel>().InstancePerDependency();
        builder.RegisterType<DataGridPage>().InstancePerDependency();

        builder.RegisterType<ContentGridDetailViewModel>().InstancePerDependency();
        builder.RegisterType<ContentGridDetailPage>().InstancePerDependency();

        builder.RegisterType<ContentGridViewModel>().InstancePerDependency();
        builder.RegisterType<ContentGridPage>().InstancePerDependency();

        builder.RegisterType<ListDetailsViewModel>().InstancePerDependency();
        builder.RegisterType<ListDetailsPage>().InstancePerDependency();

        builder.RegisterType<WebViewViewModel>().InstancePerDependency();
        builder.RegisterType<WebViewPage>().InstancePerDependency();

        builder.RegisterType<MainViewModel>().InstancePerDependency();
        builder.RegisterType<MainPage>().InstancePerDependency();
    }
}