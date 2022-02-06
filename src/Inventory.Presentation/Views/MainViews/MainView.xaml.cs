using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.MainViewModels;
using Inventory.Presentation.Views.ProductsViews;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.MainViews;

public sealed partial class MainView : Page
{
    public MainView()
    {
        InitializeComponent();
        MainViewModel = Ioc.Default.GetRequiredService<MainViewModel>();

        // frame.Navigate(typeof(ProductsView));
    }

    public MainViewModel MainViewModel { get; private set; }
}