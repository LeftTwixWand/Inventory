using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Services.Navigation;

namespace Inventory.Application.ViewModels.Dashboard;

public sealed partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "myText";
}