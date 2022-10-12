using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Activation;
using Inventory.Infrastructure.AutofacModules;
using Inventory.Persistence.Database.AutofacModules;
using Inventory.Presentation.Views.Shell;
using Microsoft.UI.Xaml;

namespace Inventory.Infrastructure;

public partial class App : Microsoft.UI.Xaml.Application
{
    public App()
    {
        InitializeComponent();

        UnhandledException += App_UnhandledException;

        // Configuration
        // TODO: Update Configure method to use IHostBuilder.ConfigureAppConfiguration
        // Add Autofac.Configuration provider
        // services.Configure<LocalSettingsOptions>(hostBuilderContext.Configuration.GetSection(nameof(LocalSettingsOptions)));
        var serviceProvider = CreateServiceProfider();
        Ioc.Default.ConfigureServices(serviceProvider);
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        var shellView = Ioc.Default.GetRequiredService<ShellView>();
        var activationService = Ioc.Default.GetRequiredService<IActivationService>();

        await activationService.ActivateAsync(shellView, args);
    }

    private static AutofacServiceProvider CreateServiceProfider()
    {
        var builder = new ContainerBuilder();

        builder
            .RegisterModule<ActivationModule>()

            .RegisterModule<NavigationModule>()

            .RegisterModule<ServicesModule>()

            .RegisterModule<MediatorModule>()

            .RegisterModule<ProcessingModule>()

            .RegisterModule<MappingModule>()

            .RegisterModule<LoggingModule>()

            .RegisterModule<DatabaseModule>();

        var container = builder.Build();
        return new AutofacServiceProvider(container);
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }
}