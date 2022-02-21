using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Products.GetProducts;
using Inventory.Application.Products.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.BaseViewModels;
using MediatR;

namespace Inventory.Application.ViewModels.ProductsViewModels;

public sealed partial class ProductsViewModel : GenericCollectionViewModel<ProductModel>
{
    public ProductsViewModel(IMediator mediator, INavigationService navigationService)
        : base(mediator, navigationService)
    {
    }

    public override string HeaderText => "Products";

    protected override void AddNew()
    {
    }

    protected override void DeleteSelection()
    {
    }

    protected override void ItemClick()
    {
    }

    protected override void Refresh()
    {
    }

    [ICommand]
    private async Task OnLoad()
    {
        await foreach (var item in Mediator.CreateStream(new GetProductsStream()))
        {
            Items.Add(item);
        }
    }
}