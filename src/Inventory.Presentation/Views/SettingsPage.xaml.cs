using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.Main;
using Inventory.Application.ViewModels.Settings;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views;

// TODO: Set the URL for your privacy policy by updating SettingsPage_PrivacyTermsLink.NavigateUri in Resources.resw.
public sealed partial class SettingsPage : Page
{
    public SettingsPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<SettingsViewModel>();
        InitializeComponent();
    }

    public SettingsViewModel ViewModel { get; }
}