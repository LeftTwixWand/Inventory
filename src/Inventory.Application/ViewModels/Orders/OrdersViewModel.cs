using CommunityToolkit.Mvvm.ComponentModel;

namespace Inventory.Application.ViewModels.Orders;

public sealed partial class OrdersViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "Some text";
}