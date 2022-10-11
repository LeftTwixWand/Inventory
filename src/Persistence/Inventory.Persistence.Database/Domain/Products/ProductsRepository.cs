using Inventory.Domain.Products;
using Inventory.Persistence.Database.Properties;
using System.Runtime.CompilerServices;

namespace Inventory.Persistence.Database.Domain.Products;

internal sealed class ProductsRepository : IProductsRepository
{
    private readonly List<Product> _products = new(
        new[]
        {
            Product.Create("Gray Mini Lamp", "Dasktop Lamp", "", Resources.Lamp1),
            Product.Create("Modern LED Lamp", "Dasktop Lamp", "", Resources.Lamp2),
            Product.Create("15\" Table Lamp", "Dasktop Lamp", "", Resources.Lamp3),
            Product.Create("Matte Balck Lamp", "Floor Lamp", "", Resources.Lamp6),
            Product.Create("Geometric Lamp", "Dasktop Lamp", "", Resources.Lamp7),
            Product.Create("Gray 20\" Lamp", "Dasktop Lamp", "", Resources.Lamp8),
            Product.Create("70\" Shared Lamp", "Floor Lamp", "", Resources.Lamp4),
            Product.Create("Rechargeable Lamp", "Outdoor Lamp", "", Resources.Lamp5),
        });

    public async IAsyncEnumerable<Product> GetProductsAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            foreach (var product in _products)
            {
                await Task.CompletedTask;
                //await Task.Delay(100, cancellationToken);
                yield return product;
            }
        }
    }
}