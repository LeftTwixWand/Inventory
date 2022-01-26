using MediatR;

namespace BuildingBlocks.Application.Requests;

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="IRequest"/> and adding request identity.
/// </summary>
public abstract record RequestBase : IRequest, IRequestIdentity
{
    /// <inheritdoc/>
    public Guid RequestId { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestBase"/> class.
    /// </summary>
    protected RequestBase()
    {
        RequestId = Guid.NewGuid();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestBase"/> class.
    /// </summary>
    /// <param name="id">External identifier of the request.</param>
    protected RequestBase(Guid id)
    {
        RequestId = id;
    }
}

/// <summary>
/// Abstract record, that encapsulate functionality of <see cref="IRequest{TResult}"/> and adding request identity.
/// <para/><typeparamref name="TResult"/> is the type of an object, that will be returned as the result of the command execution
/// </summary>
/// <typeparam name="TResult">Type of the object, that will be returned as the command execution result.</typeparam>
public abstract record RequestBase<TResult> : IRequest<TResult>, IRequestIdentity
{
    /// <inheritdoc/>
    public Guid RequestId { get; private set; }

    /// <inheritdoc cref="RequestBase()"/>
    protected RequestBase()
    {
        RequestId = Guid.NewGuid();
    }

    /// <summary>
    /// <inheritdoc cref="RequestBase(Guid)"/>
    /// </summary>
    /// <param name="id"><inheritdoc cref="RequestBase(Guid)" path="/param"/></param>
    protected RequestBase(Guid id)
    {
        RequestId = id;
    }
}