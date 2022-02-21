using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Activation;
using Inventory.Configuration;
using Inventory.Prerequisite.Win32.WindowIconLoaders;
using Inventory.Presentation.Views.MainViews;
using Microsoft.UI.Xaml;

namespace Inventory;

public partial class App : Microsoft.UI.Xaml.Application
{
    public App()
    {
        InitializeComponent();
    }

    public Window? Window { get; private set; }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        // Windows must be initialized at the OnLaunched step because of WinAPI resources allocation.
        Window = new Window()
        {
            Title = "Inventory",
        };

        Ioc.Default.ConfigureServices(Startup.ConfigureServices());

        InitializeWindow();

        var activationService = Ioc.Default.GetRequiredService<IActivationService>();
        await activationService.ActivateAsync(args);
    }

    private void InitializeWindow()
    {
        if (Window is null)
        {
            throw new NullReferenceException("Window is null on InitializeWindow");
        }

        Window.LoadIcon(@"Assets\Icons\WindowIcon.ico");
        Window.Content = new MainView();
    }
}