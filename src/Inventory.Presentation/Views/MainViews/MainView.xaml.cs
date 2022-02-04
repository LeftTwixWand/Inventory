using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.MainViewModels;
using Inventory.Presentation.Views.DashboardViews;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Inventory.Presentation.Views.MainViews;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainView : Page
{
    public MainView()
    {
        InitializeComponent();
        MainViewModel = Ioc.Default.GetRequiredService<MainViewModel>();
        frame.Navigate(typeof(DashboardView));
    }

    public MainViewModel MainViewModel { get; private set; }
}