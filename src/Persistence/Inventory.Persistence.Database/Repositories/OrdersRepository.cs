using Inventory.Domain.Orders;
using Inventory.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence.Database.Repositories;

internal sealed class OrdersRepository : IOrdersRepository
{
    private readonly DatabaseContext _databaseContext;

    public OrdersRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<ProductId>> GetListOfUsedProducts(ProductId[] products, CancellationToken cancellationToken)
    {
        var result = await _databaseContext
            .Orders
            .SelectMany(order => order.OrderItems)
            .Where(orderItem => products.Contains(orderItem.Product.Id))
            .Select(orderItem => orderItem.Product.Id)
            .ToListAsync(cancellationToken);

        return result;
    }
}