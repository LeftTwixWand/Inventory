using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.WinUI.Helpers;
using Inventory.Application.Services.SampleData;
using Inventory.Application.Services.ThemeSelector;
using Inventory.Application.Services.WebView;
using Inventory.Infrastructure.Services.SampleData;
using Inventory.Infrastructure.Services.ThemeSelector;
using Inventory.Infrastructure.Services.WebView;
using Windows.Storage;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance(new ApplicationDataStorageHelper(ApplicationData.Current)).SingleInstance();

        builder.RegisterType<WebViewService>().As<IWebViewService>().SingleInstance();

        builder.RegisterType<SampleDataService>().As<ISampleDataService>().SingleInstance();
        builder.RegisterType<ThemeSelectorService>().As<IThemeSelectorService>().SingleInstance();
        builder.RegisterInstance<IMessenger>(WeakReferenceMessenger.Default).SingleInstance();
    }
}