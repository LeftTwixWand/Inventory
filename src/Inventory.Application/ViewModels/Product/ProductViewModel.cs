using BuildingBlocks.Application.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using Inventory.Application.DomainOperations.Product.GetProductById;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using MediatR;

namespace Inventory.Application.ViewModels.Product;

public sealed partial class ProductViewModel : GenericItemViewModel<ProductModel>, INavigationAware
{
    private readonly IMediator _mediator;

    public ProductViewModel(IMediator mediator, IMessenger messenger)
        : base(messenger)
    {
        _mediator = mediator;
    }

    public void OnNavigatedFrom()
    {
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is not int productId)
        {
            return;
        }

        var product = await _mediator.Send(new GetProductByIdQuery(productId));
        Item = product ?? new ProductModel() { Name = "Product name" };
    }
}