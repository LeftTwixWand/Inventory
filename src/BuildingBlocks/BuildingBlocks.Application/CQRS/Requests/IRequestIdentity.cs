﻿using MediatR;

namespace BuildingBlocks.Application.CQRS.Requests;

/// <summary>
/// Adds unique identifier for request.
/// </summary>
public interface IIdentifiableRequest : IRequest
{
    /// <summary>
    /// Unique identifier of request.
    /// </summary>
    Guid RequestId { get; }
}

/// <summary>
/// Adds unique identifier for request.
/// </summary>
/// <typeparam name="TResult">Type of the object, that will be returned as the command execution result.</typeparam>
public interface IIdentifiableRequest<TResult> : IRequest<TResult>
{
    /// <summary>
    /// Unique identifier of request.
    /// </summary>
    Guid RequestId { get; }
}