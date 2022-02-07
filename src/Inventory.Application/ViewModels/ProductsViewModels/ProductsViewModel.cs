using System.Collections.ObjectModel;
using Inventory.Application.Products.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.BaseViewModels;
using MediatR;

namespace Inventory.Application.ViewModels.ProductsViewModels;

public partial class ProductsViewModel : GenericViewModel<ProductModel>
{
    public ProductsViewModel(IMediator mediator, INavigationService navigationService)
        : base(mediator, navigationService)
    {
        Items = new ObservableCollection<ProductModel>(new()
        {
            new ProductModel() { ProdcutID = 1, Name = "Name1", CategoryName = "Category name1" },
            new ProductModel() { ProdcutID = 1, Name = "Name2", CategoryName = "Category name1" },
            new ProductModel() { ProdcutID = 1, Name = "Name3", CategoryName = "Category name1" },
            new ProductModel() { ProdcutID = 1, Name = "Name4", CategoryName = "Category name1" },
            new ProductModel() { ProdcutID = 1, Name = "Name5", CategoryName = "Category name1" },
            new ProductModel() { ProdcutID = 1, Name = "Name6", CategoryName = "Category name1" },
            new ProductModel() { ProdcutID = 1, Name = "Name7", CategoryName = "Category name1" },
        });
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
}