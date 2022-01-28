using BuildingBlocks.Application.Commands;
using BuildingBlocks.Domain.UnitOfWorks;
using MediatR;

namespace Inventory.Infrastructure.Decorators.UnitOfWork;

internal sealed class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T>
       where T : ICommand
{
    private readonly ICommandHandler<T> _decorated;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(ICommandHandler<T> decorated, IUnitOfWork unitOfWork)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
    {
        await _decorated.Handle(command, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Unit.Value;
    }
}