using System.Collections.ObjectModel;
using BuildingBlocks.Application.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.DomainOperations.Product.GetProducts;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.Product;
using MediatR;

namespace Inventory.Application.ViewModels.Products;

public sealed partial class ProductsViewModel : GenericListViewModel<ProductModel>
{
    private readonly IMediator _mediator;
    private readonly INavigationService _navigationService;

    public ProductsViewModel(IMediator mediator, INavigationService navigationService)
    {
        _mediator = mediator;
        _navigationService = navigationService;
    }

    protected override void OnCreateNewItem()
    {
        _navigationService.NavigateTo(typeof(ProductViewModel).FullName!);
    }

    [RelayCommand]
    private async void Loaded()
    {
        await foreach (var item in _mediator.CreateStream(new GetProductsStreamQuery()))
        {
            Items.Add(item);
        }
    }

    [RelayCommand]
    private void ItemClicked(ProductModel clickedItem)
    {
        _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
        _navigationService.NavigateTo(typeof(ProductViewModel).FullName!, clickedItem.Id);
    }
}