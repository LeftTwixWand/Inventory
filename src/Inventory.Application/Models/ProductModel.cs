using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media;

namespace Inventory.Application.Models;

public sealed partial class ProductModel : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private string category = string.Empty;

    [ObservableProperty]
    private string? description;

    [ObservableProperty]
    private ImageSource? imageSource;

    [ObservableProperty]
    private decimal price;
}