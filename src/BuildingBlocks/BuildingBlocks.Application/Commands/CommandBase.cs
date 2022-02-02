using BuildingBlocks.Application.Requests;
using MediatR;

namespace BuildingBlocks.Application.Commands;

/// <inheritdoc/>
public record CommandBase : CommandBase<Unit>, ICommand
{
}

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="ICommand{TResult}"/> and adding request identity.
/// </summary>
/// <typeparam name="TResult"><inheritdoc cref="RequestBase{TResult}" path="/typeparam"/></typeparam>
public record CommandBase<TResult> : RequestBase<TResult>, ICommand<TResult>
{
}