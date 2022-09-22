using MediatR;

namespace BuildingBlocks.Application.Requests;

/// <inheritdoc/>
public record RequestBase : RequestBase<Unit>
{
    protected RequestBase()
        : base()
    {
    }

    protected RequestBase(Guid id)
        : base(id)
    {
    }
}

/// <summary>
/// Encapsulate functionality of <see cref="IRequest{TResult}"/> and adds request identity.
/// <para/><typeparamref name="TResult"/> is the type of an object, that will be returned as the result of the command execution.
/// </summary>
/// <typeparam name="TResult">Type of the object, that will be returned as the command execution result.</typeparam>
public record RequestBase<TResult> : IIdentifiableRequest<TResult>
{
    /// <inheritdoc/>
    public Guid RequestId { get; private set; }

    protected RequestBase()
    {
        RequestId = Guid.NewGuid();
    }

    protected RequestBase(Guid id)
    {
        RequestId = id;
    }
}