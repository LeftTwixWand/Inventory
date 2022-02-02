using BuildingBlocks.Application.Requests;

namespace BuildingBlocks.Application.Queries;

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="IQuery{TResult}"/> and adding request identity.
/// </summary>
/// <typeparam name="TResult"><inheritdoc cref="RequestBase{TResult}" path="/typeparam"/></typeparam>
public record QueryBase<TResult> : RequestBase<TResult>, IQuery<TResult>
{
}