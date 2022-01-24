namespace BuildingBlocks.Application.Requests;

/// <summary>
/// Add unique identifyier for request.
/// </summary>
public interface IRequestIdentity
{
    /// <summary>
    /// Unique identifyier of request.
    /// </summary>
    Guid Id { get; }
}