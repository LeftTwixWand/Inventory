using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Activation;
using Inventory.Infrastructure.AutofacModules;
using Inventory.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using Microsoft.UI.Xaml;
using Serilog;
using Serilog.Formatting.Compact;

namespace Inventory.Infrastructure;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Microsoft.UI.Xaml.Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    private readonly IHost _host;

    public App()
    {
        InitializeComponent();

        UnhandledException += App_UnhandledException;

        _host = Host
            .CreateDefaultBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .ConfigureServices(ConfigureServices)
            .UseSerilog(ConfigureLogging)
            .ConfigureAppConfiguration(CreateConfiguration)
            .Build();

        // Services
        //        services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
        //        services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
        //        services.AddTransient<IWebViewService, WebViewService>();
        //        services.AddTransient<INavigationViewService, NavigationViewService>();

        // Core Services
        //        services.AddSingleton<ISampleDataService, SampleDataService>();
        //        services.AddSingleton<IFileService, FileService>();

        // Configuration
        //        services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));

        // We need the navigation service dependency in navigation Behaviors
        // TODO: Improve dependency injection into navigation Behaviors
        Ioc.Default.ConfigureServices(_host.Services);
    }

    private void CreateConfiguration(HostBuilderContext hostBuilderContext, IConfigurationBuilder configurationBuilder)
    {
        //configurationBuilder.Configure<LocalSettingsOptions>(hostBuilderContext.Configuration.GetSection(nameof(LocalSettingsOptions)));
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        var activationService = _host.Services.GetService<IActivationService>();
        Guard.IsNotNull(activationService, nameof(activationService));

        await activationService.ActivateAsync(args, _host.Services);
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    private void ConfigureServices(IServiceCollection services)
    {
            services.Scan
        //builder.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        //.RegisterModule<ActivationModule>()
        //.RegisterModule<NavigationModule>();

    }

    public static void RegisterAllTypes<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        services.Scan(
            x =>
            {
                x.FromApplicationDependencies()
                    .AddClasses(classes => classes.AssignableTo(typeof(T)))
                        .AsImplementedInterfaces()
                        .WithLifetime(lifetime);
            });
    }

    private void ConfigureLogging(HostBuilderContext hostBuilderContext, LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration
            .Enrich.FromLogContext()
            .WriteTo.Debug(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
    }
}