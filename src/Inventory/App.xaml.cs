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

public sealed partial class App : Microsoft.UI.Xaml.Application
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
            .Build();
    }

    // Window must be static, because of WinAPI resources allocation.
    public static Window MainWindow { get; private set; } = new Window() { Title = "Inventory", };

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        var activationService = _host.Services.GetRequiredService<IActivationService>();
        await activationService.ActivateAsync(args.Arguments, _host.Services);
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