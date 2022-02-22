using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Activation;
using Inventory.Configurations;
using Inventory.Prerequisite.Win32.WindowIconLoaders;
using Microsoft.UI.Xaml;

namespace Inventory;

public partial class App : Microsoft.UI.Xaml.Application
{
    public App()
    {
        InitializeComponent();

        UnhandledException += App_UnhandledException;
    }

    // Windows must be static, because of WinAPI resources allocation.
    public static Window MainWindow { get; private set; } = new Window() { Title = "Inventory", };

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        Ioc.Default.ConfigureServices(Startup.ConfigureServices());

        var activationService = Ioc.Default.GetRequiredService<IActivationService>();
        await activationService.ActivateAsync(args);

        InitializeWindow();
    }

    private static void InitializeWindow()
    {
        WindowIconLoader.LoadIcon(MainWindow, @"Assets\Icons\WindowIcon.ico");

        // MainWindow.Content = new MainView();
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        throw new NotImplementedException();
    }
}