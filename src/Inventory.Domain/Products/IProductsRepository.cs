namespace Inventory.Domain.Products;

public interface IProductsRepository
{
    IAsyncEnumerable<Product> GetAllAsync(CancellationToken cancellationToken);

    Task<Product?> GetByIdAsync(int id);
}