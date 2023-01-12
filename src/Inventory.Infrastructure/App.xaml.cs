using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Activation;
using Inventory.Infrastructure.AutofacModules;
using Inventory.Persistence.Database.AutofacModules;
using Inventory.Presentation.Views.Shell;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace Inventory.Infrastructure;

public sealed partial class App : Microsoft.UI.Xaml.Application
{
    private readonly IHost _host;

    public App()
    {
        InitializeComponent();


        _host = Host.CreateApplicationBuilder().Build();

        UnhandledException += App_UnhandledException;

        // Configuration
        // TODO: Update Configure method to use IHostBuilder.ConfigureAppConfiguration
        // Add Autofac.Configuration provider
        // services.Configure<LocalSettingsOptions>(hostBuilderContext.Configuration.GetSection(nameof(LocalSettingsOptions)));
        Ioc.Default.ConfigureServices(_host.Services);
    }

    private void ConfigureServices(ContainerBuilder builder)
    {
        builder
            .RegisterModule<ActivationModule>()

            .RegisterModule<NavigationModule>()

            .RegisterModule<ServicesModule>()

            .RegisterModule<MediatorModule>()

            .RegisterModule<ProcessingModule>()

            .RegisterModule<MappingModule>()

            .RegisterModule<LoggingModule>()

            .RegisterModule<DatabaseModule>();
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        var shellView = Ioc.Default.GetRequiredService<ShellView>();
        var activationService = Ioc.Default.GetRequiredService<IActivationService>();

        await activationService.ActivateAsync(shellView, args);
    }

    private static IConfigurationRoot CreateConfigurationBuilder()
    {
        // Add the configuration to the ConfigurationBuilder.
        var config = new ConfigurationBuilder();

        // config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
        // config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
        config.AddJsonFile("autofac.json");

        return config.Build();
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }
}