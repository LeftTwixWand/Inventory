using Inventory.Infrastructure.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace Inventory.Infrastructure.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
