using BuildingBlocks.Application.CQRS.Requests;

namespace BuildingBlocks.Application.CQRS.Queries;

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="IQuery{TResult}"/> and adding request identity.
/// </summary>
/// <typeparam name="TResult"><inheritdoc cref="RequestBase{TResult}" path="/typeparam"/></typeparam>
public abstract record QueryBase<TResult> : RequestBase<TResult>, IQuery<TResult>;