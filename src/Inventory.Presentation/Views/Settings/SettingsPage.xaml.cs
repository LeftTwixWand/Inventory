using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.Settings;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.Settings;

public sealed partial class SettingsPage : Page
{
    public SettingsPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<SettingsViewModel>();
        InitializeComponent();
    }

    public SettingsViewModel ViewModel { get; }
}