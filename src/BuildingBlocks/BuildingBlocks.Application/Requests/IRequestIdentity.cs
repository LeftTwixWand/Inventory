using MediatR;

namespace BuildingBlocks.Application.Requests;

/// <summary>
/// Adds unique identifyier for request.
/// </summary>
/// <typeparam name="TResult">Return type.</typeparam>
public interface IIdentifiableRequest<out TResult> : IRequest<TResult>
{
    /// <summary>
    /// Unique identifyier of request.
    /// </summary>
    Guid RequestId { get; }
}