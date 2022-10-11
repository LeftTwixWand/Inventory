using CommunityToolkit.Mvvm.ComponentModel;

namespace Inventory.Application.ViewModels.Products;

public sealed partial class ProductsViewModel : ObservableObject
{
    [ObservableProperty]
    private string myText = "Some text";
}