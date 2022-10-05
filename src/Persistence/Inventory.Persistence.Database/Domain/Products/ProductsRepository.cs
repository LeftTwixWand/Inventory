using Inventory.Domain.Categories;
using Inventory.Domain.Products;
using System.Runtime.CompilerServices;

namespace Inventory.Persistence.Database.Domain.Products;

internal sealed class ProductsRepository : IProductsRepository
{
    private readonly List<Product> _products = new(
        new[]
        {
            Product.Create("Lamp1", 1, 10, Category.Create("lamps")),
            Product.Create("Lamp2", 2, 20, Category.Create("lamps")),
            Product.Create("Lamp3", 3, 30, Category.Create("lamps")),
            Product.Create("Lamp4", 4, 40, Category.Create("lamps")),
            Product.Create("Lamp5", 5, 50, Category.Create("lamps")),
        });

    public async IAsyncEnumerable<Product> GetProductsAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var product in _products)
        {
            await Task.Delay(100, cancellationToken);
            yield return product;
        }
    }
}