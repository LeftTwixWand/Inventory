using CommunityToolkit.Mvvm.ComponentModel;

namespace Inventory.Application.Products.Models;

public sealed class ProductModel : ObservableObject
{
    public long ProductID { get; set; }

    public string Name { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public decimal ListPrice { get; set; }

    public decimal DealerPrice { get; set; }

    public decimal Discount { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset LastModifiedOn { get; set; }

    public int StockUnits { get; set; }

    public int SafetyStockLevel { get; set; }

    public byte[]? Picture { get; set; }
}