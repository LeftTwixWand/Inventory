using BuildingBlocks.Application.Commands;
using MediatR;

namespace Inventory.Application.Products.CreateNewProduct;

//[Inject]
public sealed class CreateNewProductCommandHandler : ICommandHandler<CreateNewProductCommand>
{
    public Task<Unit> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Unit.Value);
    }
}

public sealed class CreateNewProductCommandResultHandler : ICommandHandler<CreateNewProductCommandResult, string>
{
    public Task<string> Handle(CreateNewProductCommandResult request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request.Name);
    }
}