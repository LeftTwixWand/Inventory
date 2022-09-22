using Inventory.Application.ViewModels.Main;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views;

public sealed partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }

    public MainViewModel ViewModel { get; }
}