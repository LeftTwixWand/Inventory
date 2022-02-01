using BuildingBlocks.Application.Commands;
using BuildingBlocks.Domain.UnitOfWorks;
using MediatR;

namespace Inventory.Infrastructure.Decorators.UnitOfWork;

internal sealed class UnitOfWorkCommandHandlerWithResultDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
{
    private readonly IRequestHandler<TCommand, TResult> _decorated;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerWithResultDecorator(IRequestHandler<TCommand, TResult> decorated, IUnitOfWork unitOfWork)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
    }

    public async Task<TResult> Handle(TCommand comamnd, CancellationToken cancellationToken)
    {
        var result = await _decorated.Handle(comamnd, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return result;
    }
}