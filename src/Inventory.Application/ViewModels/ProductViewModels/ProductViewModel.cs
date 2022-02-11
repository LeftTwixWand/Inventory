using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Products.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.BaseViewModels;
using MediatR;

namespace Inventory.Application.ViewModels.ProductViewModels;

public partial class ProductViewModel : GenericDetailsViewModel<ProductModel>
{
    [ObservableProperty]
    private object? newPictureSource = null;

    public ProductViewModel(IMediator mediator, INavigationService navigationService)
        : base(mediator, navigationService)
    {
        Item = new ProductModel()
        {
            ProductID = 1,
            Name = "MyName",
            CategoryName = "MyCategoryName",
            CreatedOn = DateTime.Now,
            DealerPrice = 999,
            Discount = 2,
            LastModifiedOn = DateTime.Now,
            ListPrice = 22,
            Picture = null,
            Price = 93,
            SafetyStockLevel = 1,
            StockUnits = 56,
        };
    }

    protected override Task Cancel()
    {
        throw new NotImplementedException();
    }

    protected override Task Delete()
    {
        throw new NotImplementedException();
    }

    protected override Task Edit()
    {
        throw new NotImplementedException();
    }

    protected override Task Save()
    {
        throw new NotImplementedException();
    }

    [ICommand]
    private void EditPicture()
    {
        throw new NotImplementedException();
    }
}