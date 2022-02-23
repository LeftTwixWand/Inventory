using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.MainViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.MainViews;

public sealed partial class MainView : Page
{
    public MainView()
    {
        ViewModel = Ioc.Default.GetRequiredService<MainViewModel>();

        InitializeComponent();

        ViewModel.NavigationService.Frame = frame;
        ViewModel.NavigationViewService.Initialize(navigationView);
    }

    public MainViewModel ViewModel { get; }
}