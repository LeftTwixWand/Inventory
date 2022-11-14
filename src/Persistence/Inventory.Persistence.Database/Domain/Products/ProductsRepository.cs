using Inventory.Domain.Products;
using Inventory.Persistence.Database.Properties;
using System.Runtime.CompilerServices;

namespace Inventory.Persistence.Database.Domain.Products;

internal sealed class ProductsRepository : IProductsRepository
{
    private readonly List<Product> _products = new(
        new[]
        {
            Product.Create("Gray Mini Lamp", "Desktop Lamp", "", Resources.Lamp1),
            Product.Create("Modern LED Lamp", "Desktop Lamp", "", Resources.Lamp2),
            Product.Create("15\" Table Lamp", "Desktop Lamp", "", Resources.Lamp3),
            Product.Create("Matte Balck Lamp", "Floor Lamp", "", Resources.Lamp6),
            Product.Create("Geometric Lamp", "Desktop Lamp", "", Resources.Lamp7),
            Product.Create("Gray 20\" Lamp", "Desktop Lamp", "", Resources.Lamp8),
            Product.Create("70\" Shared Lamp", "Floor Lamp", "", Resources.Lamp4),
            Product.Create("Rechargeable Lamp", "Outdoor Lamp", "", Resources.Lamp5),
        });

    public async IAsyncEnumerable<Product> GetAllAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        for (int i = 0; i < 10; i++)
        {
            foreach (var product in _products)
            {
                yield return product;
            }
        }
    }

    public Task<Product?> GetByIdAsync(ProductId id)
    {
        var product = _products.FirstOrDefault(product => product.Id == id);
        return Task.FromResult(product);
    }
}