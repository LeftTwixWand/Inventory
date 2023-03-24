namespace Inventory.Domain.Products;

public interface IProductsRepository
{
    IAsyncEnumerable<Product> GetAllAsync(CancellationToken cancellationToken);

    Task<Product?> GetByIdAsync(ProductId id, CancellationToken cancellationToken);

    Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
}