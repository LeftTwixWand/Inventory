using System;
using System.Threading.Tasks;
using BuildingBlocks.Application.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using Inventory.Application.Features.Products.GetProductById;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using MediatR;

namespace Inventory.Application.ViewModels.Product;

public sealed partial class ProductViewModel : GenericItemViewModel<ProductModel>, INavigatedTo<Guid>
{
    private readonly IMediator _mediator;

    public ProductViewModel(IMediator mediator, IMessenger messenger)
        : base(messenger)
    {
        _mediator = mediator;
    }

    public async Task OnNavigatedTo(Guid productId)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(productId));
        Item = product ?? new ProductModel() { Name = "Product doesn't exist: Default product name" };
    }
}