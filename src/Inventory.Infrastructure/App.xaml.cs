using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Activation;
using Inventory.Infrastructure.AutofacModules;
using Inventory.Persistence.Database.AutofacModules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using Serilog;

namespace Inventory.Infrastructure;

public partial class App : Microsoft.UI.Xaml.Application
{
    private readonly IHost _host;

    public App()
    {
        InitializeComponent();

        UnhandledException += App_UnhandledException;

        _host = Host
            .CreateDefaultBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory(ConfigureServices))
            .ConfigureLogging(ConfigureLogging)
            .Build();

        // Configuration
        // TODO: Update Configure method to use IHostBuilder.ConfigureAppConfiguration
        // Add Autofac.Configuration provider
        // services.Configure<LocalSettingsOptions>(hostBuilderContext.Configuration.GetSection(nameof(LocalSettingsOptions)));

        // We need the navigation service dependency in navigation Behaviors
        // TODO: Improve dependency injection into navigation Behaviors
        Ioc.Default.ConfigureServices(_host.Services);
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        var activationService = _host.Services.GetRequiredService<IActivationService>();

        await activationService.ActivateAsync(args, _host.Services);
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
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

            .RegisterModule<DatabaseModule>();
    }

    private void ConfigureLogging(ILoggingBuilder builder)
    {
        var logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.Debug(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
                    .CreateLogger();

        builder.AddSerilog(logger);
    }
}