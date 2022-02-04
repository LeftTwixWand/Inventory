using CommunityToolkit.Mvvm.ComponentModel;

namespace Inventory.Application.Products.Models;

public class ProductModel : ObservableObject
{
    public long ProdcutID { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }
}