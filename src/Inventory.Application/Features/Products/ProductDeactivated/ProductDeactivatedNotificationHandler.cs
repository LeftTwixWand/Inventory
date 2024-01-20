using System.Threading;
using System.Threading.Tasks;
using Inventory.Domain.Warehouses.Events;
using MediatR;

namespace Inventory.Application.Features.Products.ProductDeactivated;

internal sealed class ProductDeactivatedNotificationHandler : INotificationHandler<ProductDeactivatedEvent>
{
    public Task Handle(ProductDeactivatedEvent @event, CancellationToken cancellationToken)
    {
        if (@event.RemainingProductsQuantity > 0)
        {
            // Handle remaining products management in warehouse.
        }

        return Task.CompletedTask;
    }
}