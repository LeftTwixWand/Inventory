using BuildingBlocks.Application.Requests;
using MediatR;

namespace BuildingBlocks.Application.Commands;

/// <inheritdoc/>
public interface ICommand : ICommand<Unit>
{
}

/// <summary>
/// Abstraction, needed for Commands segrigation in CQRS architecture approach.
/// <para><typeparamref name="TResult"/> is the type of the object, that will be returned as the command execution result.</para>
/// </summary>
/// <typeparam name="TResult"><inheritdoc/></typeparam>
public interface ICommand<out TResult> : IIdentifiableRequest<TResult>
{
}