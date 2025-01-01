using eShopOnWinUI.Domain.SeedWork.UnitOfWorks;
using eShopOnWinUI.Infrastructure.UnitOfWorks.DataStorage;
using eShopOnWinUI.Infrastructure.UnitOfWorks.DomainEventsDispatching;

namespace eShopOnWinUI.Infrastructure.UnitOfWorks;

public partial class UnitOfWork(IDataStorage dataStorageDispatcher, IDomainEventsDispatcher domainEventsDispatcher) : IUnitOfWork
{
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        await domainEventsDispatcher.DispatchEventsAsync(cancellationToken);

        return await dataStorageDispatcher.SaveChangesAsync(cancellationToken);
    }
}