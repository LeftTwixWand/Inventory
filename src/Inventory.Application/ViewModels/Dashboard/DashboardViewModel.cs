using CommunityToolkit.Mvvm.ComponentModel;

namespace Inventory.Application.ViewModels.Dashboard;

public sealed partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "myText";
}