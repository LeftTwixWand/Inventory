using CommunityToolkit.WinUI;
using Inventory.Application.ViewModels.MainViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.MainViews;

public sealed partial class MainView : Page
{
    public MainView(MainViewModel viewModel, Window window)
    {
        ViewModel = viewModel;
        InitializeComponent();

        ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.NavigationViewService.Initialize(NavigationViewControl);

        // TODO: Set the title bar icon by updating /Assets/WindowIcon.ico.
        // A custom title bar is required for full window theme and Mica support.
        // https://docs.microsoft.com/windows/apps/develop/title-bar?tabs=winui3#full-customization
        window.ExtendsContentIntoTitleBar = true;
        window.SetTitleBar(AppTitleBar);
        AppTitleBarText.Text = "AppDisplayName".GetLocalized();
    }

    public MainViewModel ViewModel { get; }
}