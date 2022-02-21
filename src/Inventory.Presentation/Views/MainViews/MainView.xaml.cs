using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.MainViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.MainViews;

public sealed partial class MainView : Page
{
    public MainView()
    {
        InitializeComponent();
        MainViewModel = Ioc.Default.GetRequiredService<MainViewModel>();
    }

    public MainViewModel MainViewModel { get; set; }
}