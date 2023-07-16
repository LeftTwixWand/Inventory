using Inventory.Domain.Products;

namespace Inventory.Domain.Orders;

public interface IOrdersRepository
{
    Task<List<ProductId>> GetListOfUsedProducts(ProductId[] products, CancellationToken cancellationToken);
}