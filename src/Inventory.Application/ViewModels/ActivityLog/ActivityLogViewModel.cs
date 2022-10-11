using CommunityToolkit.Mvvm.ComponentModel;

namespace Inventory.Application.ViewModels.ActivityLog;

public sealed partial class ActivityLogViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "Some text";
}