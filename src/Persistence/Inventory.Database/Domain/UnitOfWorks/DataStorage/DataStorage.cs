using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DataStorage;
using HarabaSourceGenerators.Common.Attributes;

namespace Inventory.Database.Domain.UnitOfWorks.DataStorage;

[Inject]
public partial class DataStorage : IDataStorage
{
    private readonly DatabaseContext _context;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}