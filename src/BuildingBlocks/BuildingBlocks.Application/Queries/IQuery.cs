using BuildingBlocks.Application.Requests;

namespace BuildingBlocks.Application.Queries;

/// <summary>
/// Represents Query functionality in CQRS architecture approach.
/// <para><see href="https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs">Read more about CQRS</see>.</para>
/// </summary>
/// <typeparam name="TResult">Type of the object, that will be returned as the command execution result.</typeparam>
public interface IQuery<out TResult> : IIdentifiableRequest<TResult>
{
}