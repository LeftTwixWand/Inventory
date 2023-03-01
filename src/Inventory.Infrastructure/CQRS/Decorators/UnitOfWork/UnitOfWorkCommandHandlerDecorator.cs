using BuildingBlocks.Application.CQRS.Commands;
using BuildingBlocks.Domain.UnitOfWorks;
using MediatR;

namespace Inventory.Infrastructure.CQRS.Decorators.UnitOfWork;

internal sealed class UnitOfWorkCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
{
    private readonly IRequestHandler<TCommand> _decorated;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(IRequestHandler<TCommand> decorated, IUnitOfWork unitOfWork)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TCommand comamnd, CancellationToken cancellationToken)
    {
        await _decorated.Handle(comamnd, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}

internal sealed class UnitOfWorkCommandHandlerDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
{
    private readonly IRequestHandler<TCommand, TResult> _decorated;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(IRequestHandler<TCommand, TResult> decorated, IUnitOfWork unitOfWork)
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