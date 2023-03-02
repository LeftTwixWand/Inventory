using System.Runtime.CompilerServices;
using Inventory.Domain.Products;
using Inventory.Persistence.Database.Properties;

namespace Inventory.Persistence.Database.Domain.Products;

internal sealed class ProductsRepository : IProductsRepository
{
    private readonly List<Product> _products = new(new[]
    {
        Product.Create("Gray Mini Lamp", "Desktop Lamp", string.Empty, Resources.Lamp1),
        Product.Create("Modern LED Lamp", "Desktop Lamp", string.Empty, Resources.Lamp2),
        Product.Create("15\" Table Lamp", "Desktop Lamp", string.Empty, Resources.Lamp3),
        Product.Create("Matte Black Lamp", "Floor Lamp", string.Empty, Resources.Lamp6),
        Product.Create("Geometric Lamp", "Desktop Lamp", string.Empty, Resources.Lamp7),
        Product.Create("Gray 20\" Lamp", "Desktop Lamp", string.Empty, Resources.Lamp8),
        Product.Create("70\" Shared Lamp", "Floor Lamp", string.Empty, Resources.Lamp4),
        Product.Create("Rechargeable Lamp", "Outdoor Lamp", string.Empty, Resources.Lamp5),
    });

    public async IAsyncEnumerable<Product> GetAllAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            foreach (Product product in _products)
            {
                await Task.Delay(100, cancellationToken);

                yield return product;
            }
        }
    }

    public Task<Product?> GetByIdAsync(ProductId id)
    {
        Product? product = _products.FirstOrDefault(product => product.Id == id);
        return Task.FromResult(product);
    }
}