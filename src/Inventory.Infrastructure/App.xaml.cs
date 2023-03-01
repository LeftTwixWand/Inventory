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
using Serilog;

namespace Inventory.Infrastructure;

public sealed partial class App : Microsoft.UI.Xaml.Application
{
    private readonly IHost _host;

    public App()
    {
        InitializeComponent();

        _host = new HostBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder =>
            {
                containerBuilder
                    .RegisterModule<ActivationModule>()
                    .RegisterModule<NavigationModule>()
                    .RegisterModule<ServicesModule>()
                    .RegisterModule<MediatorModule>()
                    .RegisterModule<MappingModule>()
                    .RegisterModule<DatabaseModule>();
            }))
            .UseSerilog((hostBuilderContext, loggerConfiguration) =>
            {
                loggerConfiguration
                    .Enrich.FromLogContext()
                    .WriteTo.Debug(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}");
            })
            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            {
                configurationBuilder
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddJsonFile($"appsettings.{hostBuilderContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
            })
            .Build();

        UnhandledException += App_UnhandledException;

        Ioc.Default.ConfigureServices(_host.Services);
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        ShellView shellView = Ioc.Default.GetRequiredService<ShellView>();
        IActivationService activationService = Ioc.Default.GetRequiredService<IActivationService>();

        await activationService.ActivateAsync(shellView, args);
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }
}