using BuildingBlocks.Domain.UnitOfWorks;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DataStorage;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;

namespace BuildingBlocks.Infrastructure.Domain.UnitOfWorks;

public partial class UnitOfWork : IUnitOfWork
{
    private readonly IDataStorage _dataStorageDispatcher;
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public UnitOfWork(IDataStorage dataStorageDispatcher, IDomainEventsDispatcher domainEventsDispatcher)
    {
        _dataStorageDispatcher = dataStorageDispatcher;
        _domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        await _domainEventsDispatcher.DispatchEventsAsync(cancellationToken);

        return await _dataStorageDispatcher.SaveChangesAsync(cancellationToken);
    }
}