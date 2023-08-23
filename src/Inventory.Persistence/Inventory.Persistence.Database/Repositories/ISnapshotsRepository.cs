using Inventory.Domain.Products;
using Inventory.Persistence.Database.Snapshots;

namespace Inventory.Infrastructure.Services.DataAccess;

internal interface ISnapshotsRepository
{
    Task<Snapshot> GetLatestAsync(ProductId productId, CancellationToken cancellationToken);
}