using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.DashboardViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.DashboardViews;

public sealed partial class DashboardView : Page
{
    public DashboardView()
    {
        ViewModel = Ioc.Default.GetRequiredService<DashboardViewModel>();
        InitializeComponent();
    }

    public DashboardViewModel ViewModel { get; }
}