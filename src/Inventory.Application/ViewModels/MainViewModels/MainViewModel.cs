using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Services.Navigation;
using Microsoft.UI.Xaml.Navigation;

namespace Inventory.Application.ViewModels.MainViewModels;

public sealed partial class MainViewModel : ObservableObject
{
    private readonly INavigationViewService _navigationViewService;

    [ObservableProperty]
    private bool isBackEnabled;

    [ObservableProperty]
    private object? selected;

    public MainViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        _navigationViewService = navigationViewService;
    }

    public INavigationService NavigationService { get; }

    public INavigationViewService NavigationViewService
    {
        get => _navigationViewService;
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem is not null)
        {
            Selected = selectedItem;
        }
    }
}