namespace Inventory.Domain.Products;

public interface IProductsRepository
{
    IAsyncEnumerable<Product> GetProductsAsync();
}