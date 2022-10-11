using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.Dashboard;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.Dashboard;

public sealed partial class DashboardView : Page
{
    public DashboardView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<DashboardViewModel>();
    }

    private DashboardViewModel ViewModel { get; }
}