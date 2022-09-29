using BuildingBlocks.Application.Services.Activation.Handlers;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Activation;
using Inventory.Application.Services.Files;
using Inventory.Application.Services.LocalSettings;
using Inventory.Application.Services.Navigation;
using Inventory.Application.Services.SampleData;
using Inventory.Application.Services.ThemeSelector;
using Inventory.Application.Services.WebView;
using Inventory.Application.ViewModels.ContentGrid;
using Inventory.Application.ViewModels.DataGrid;
using Inventory.Application.ViewModels.ListDetails;
using Inventory.Application.ViewModels.Main;
using Inventory.Application.ViewModels.Settings;
using Inventory.Application.ViewModels.Shell;
using Inventory.Application.ViewModels.WebView;
using Inventory.Infrastructure.Models;
using Inventory.Infrastructure.Services.Activation;
using Inventory.Infrastructure.Services.Files;
using Inventory.Infrastructure.Services.LocalSettings;
using Inventory.Infrastructure.Services.Navigation;
using Inventory.Infrastructure.Services.SampleData;
using Inventory.Infrastructure.Services.ThemeSelector;
using Inventory.Infrastructure.Services.WebView;
using Inventory.Presentation.Views;
using Inventory.Presentation.Views.Shell;
using Inventory.Presentation.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

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

        _host = Host
            .CreateDefaultBuilder()
            .UseContentRoot(AppContext.BaseDirectory)
            .ConfigureServices((context, services) =>
            {
                // Default Activation Handler
                services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

                // Other Activation Handlers

                // Services
                services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
                services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
                services.AddTransient<IWebViewService, WebViewService>();
                services.AddTransient<INavigationViewService, NavigationViewService>();

                services.AddSingleton<IActivationService, ActivationService>();
                services.AddSingleton<IPageService, PageService>();
                services.AddSingleton<INavigationService, NavigationService>();

                // Core Services
                services.AddSingleton<ISampleDataService, SampleDataService>();
                services.AddSingleton<IFileService, FileService>();

                services.AddSingleton<Window, MainWindow>();

                // Views and ViewModels
                services.AddTransient<SettingsViewModel>();
                services.AddTransient<SettingsPage>();
                services.AddTransient<DataGridViewModel>();
                services.AddTransient<DataGridPage>();
                services.AddTransient<ContentGridDetailViewModel>();
                services.AddTransient<ContentGridDetailPage>();
                services.AddTransient<ContentGridViewModel>();
                services.AddTransient<ContentGridPage>();
                services.AddTransient<ListDetailsViewModel>();
                services.AddTransient<ListDetailsPage>();
                services.AddTransient<WebViewViewModel>();
                services.AddTransient<WebViewPage>();
                services.AddTransient<MainViewModel>();
                services.AddTransient<MainPage>();
                services.AddTransient<ShellView>();
                services.AddTransient<ShellViewModel>();

                // Configuration
                services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
            })
            .Build();

        Ioc.Default.ConfigureServices(_host.Services);

        UnhandledException += App_UnhandledException;
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
}