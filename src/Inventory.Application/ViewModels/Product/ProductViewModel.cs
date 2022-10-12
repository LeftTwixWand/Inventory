using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.DomainOperations.Product.GetProduct;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using MediatR;

namespace Inventory.Application.ViewModels.Product;

public sealed partial class ProductViewModel : ObservableObject, INavigationAware
{
    private readonly IMediator _mediator;

    [ObservableProperty]
    private ProductModel? product;

    public ProductViewModel(IMediator mediator)
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

        Product = await _mediator.Send(new GetProductByIdQuery(productId));
    }
}