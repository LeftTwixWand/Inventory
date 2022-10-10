using Autofac;
using Inventory.Application.Services.Files;
using Inventory.Application.Services.LocalSettings;
using Inventory.Application.Services.Navigation;
using Inventory.Application.Services.SampleData;
using Inventory.Application.Services.ThemeSelector;
using Inventory.Application.Services.WebView;
using Inventory.Infrastructure.Services.Files;
using Inventory.Infrastructure.Services.LocalSettings;
using Inventory.Infrastructure.Services.Navigation;
using Inventory.Infrastructure.Services.SampleData;
using Inventory.Infrastructure.Services.ThemeSelector;
using Inventory.Infrastructure.Services.WebView;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<LocalSettingsService>().As<ILocalSettingsService>().SingleInstance();

        builder.RegisterType<ThemeSelectorService>().As<IThemeSelectorService>().SingleInstance();

        builder.RegisterType<WebViewService>().As<IWebViewService>().SingleInstance();

        builder.RegisterType<SampleDataService>().As<ISampleDataService>().SingleInstance();

        builder.RegisterType<FileService>().As<IFileService>().SingleInstance();
    }
}