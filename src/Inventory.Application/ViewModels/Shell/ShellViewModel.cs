using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Services.Navigation;
using Microsoft.UI.Xaml.Navigation;

namespace Inventory.Application.ViewModels.Shell;

public sealed partial class ShellViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBackEnabled;

    [ObservableProperty]
    private object? _selected;

    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;
    }

    public INavigationService NavigationService { get; }

    public INavigationViewService NavigationViewService { get; }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        // TODO: Update the settings page verification
        if (e.SourcePageType.FullName?.Contains("Settings") == true)
        {
            Selected = NavigationViewService.SettingsItem;
            return;
        }

        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem != null)
        {
            Selected = selectedItem;
        }
    }
}