using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.ActivityLog;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.ActivityLog;

public sealed partial class ActivityLogView : Page
{
    public ActivityLogView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<ActivityLogViewModel>();
    }

    private ActivityLogViewModel ViewModel { get; }
}