using Inventory.Domain.Products;
using Inventory.Domain.Warehouses.Projections;

namespace Inventory.Domain.Warehouses;

public interface IWarehouseAccountantService
{
    Task<ActualProductQuantityProjection> GetActualProductQuantityProjection(ProductId productId, CancellationToken cancellationToken);
}