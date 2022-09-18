using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Inventory.Application.AutofacModules;
using Inventory.Application.Services.Activation;
using Inventory.AutofacModules;
using Inventory.Configurations.Database;
using Inventory.Database.AutofacModules;
using Inventory.Infrastructure.AutofacModules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace Inventory;

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

        _host = Host
            .CreateDefaultBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory(ConfigureServices))
            .Build();

        UnhandledException += App_UnhandledException;
    }

    // Windows must be static, because of WinAPI resources allocation.
    public static Window MainWindow { get; private set; } = new Window() { Title = "Inventory", };

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await _host.Services.GetRequiredService<IActivationService>().ActivateAsync(args);
    }

    private void ConfigureServices(ContainerBuilder builder)
    {
        builder.RegisterModule<ActivationModule>();

        builder.RegisterModule<NavigationModule>();

        builder.RegisterModule<LoggingModule>();

        builder.RegisterModule<MediatorModule>();

        builder.RegisterModule<ProcessingModule>();

        builder.RegisterModule<ApplicationServicesModule>();

        builder.RegisterModule(
            new DatabaseModule(
                DatabaseConfiguration.GetOprions()));
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        throw new NotImplementedException();
    }
}