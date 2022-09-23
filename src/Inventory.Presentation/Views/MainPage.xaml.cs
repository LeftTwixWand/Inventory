using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.Main;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<MainViewModel>();
        InitializeComponent();
    }

    public MainViewModel ViewModel { get; }
}