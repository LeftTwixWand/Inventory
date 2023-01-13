using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Activation;
using Inventory.Infrastructure.AutofacModules;
using Inventory.Persistence.Database;
using Inventory.Persistence.Database.AutofacModules;
using Inventory.Presentation.Views.Shell;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            .UseServiceProviderFactory(new AutofacServiceProviderFactory(CreateContainer))
            .ConfigureServices(ConfigureServices)
            .UseSerilog(ConfigureLogging)
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

    private void ConfigureLogging(HostBuilderContext hostBuilderContext, LoggerConfiguration loggerConfiguration)
    {
        _ = loggerConfiguration
            .Enrich.FromLogContext()
            .WriteTo.Debug(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}");
    }

    private void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection serviceCollection)
    {
        SqliteConnectionStringBuilder connectionStringBuilder = new()
        {
            DataSource = "Database.db",
        };

        _ = serviceCollection.AddDbContext<DatabaseContext>(options => options.UseSqlite(connectionStringBuilder.ToString()));
    }

    private void CreateContainer(ContainerBuilder builder)
    {
        _ = builder
            .RegisterModule<ActivationModule>()

            .RegisterModule<NavigationModule>()

            .RegisterModule<ServicesModule>()

            .RegisterModule<MediatorModule>()

            .RegisterModule<ProcessingModule>()

            .RegisterModule<MappingModule>()

            .RegisterModule<DatabaseModule>();
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }
}