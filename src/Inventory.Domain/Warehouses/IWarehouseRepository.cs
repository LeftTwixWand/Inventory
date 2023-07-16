using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;

namespace Inventory.Persistence.Database.Repositories;

public interface IWarehouseRepository
{
    Task<Warehouse> GetByIdAsync(ProductId productId, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Warehouse>> GetManyByIdsAsync(List<ProductId> usedProducts, CancellationToken cancellationToken);
}