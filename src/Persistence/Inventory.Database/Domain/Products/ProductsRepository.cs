using HarabaSourceGenerators.Common.Attributes;
using Inventory.Domain.Products;

namespace Inventory.Database.Domain.Products;

[Inject]
public partial class ProductsRepository : IProductsRepository
{
    private readonly DatabaseContext _context;

    public IAsyncEnumerable<Product> GetProductsAsync()
    {
        return _context.Products.AsAsyncEnumerable();
    }
}