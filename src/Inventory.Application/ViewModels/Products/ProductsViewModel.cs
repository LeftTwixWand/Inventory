using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.DomainOperations.Product.GetProducts;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.ContentGrid;
using MediatR;

namespace Inventory.Application.ViewModels.Products;

public sealed partial class ProductsViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    private readonly INavigationService _navigationService;

    public ProductsViewModel(IMediator mediator, INavigationService navigationService)
    {
        _mediator = mediator;
        _navigationService = navigationService;
    }

    public ObservableCollection<ProductModel> Products { get; } = new();

    [RelayCommand]
    private async void Loaded()
    {
        await foreach (var item in _mediator.CreateStream(new GetProductsStreamQuery()))
        {
            Products.Add(item);
        }
    }

    [RelayCommand]
    private void ItemClick(ProductModel? clickedItem)
    {
        if (clickedItem is not null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(ContentGridDetailViewModel).FullName!, clickedItem.Id);
        }
    }
}