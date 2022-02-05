using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.BaseViewModels;
using MediatR;

namespace Inventory.Application.ViewModels.ProductsViewModels;

public class ProductsViewModel : BaseViewModel
{
    public ProductsViewModel(IMediator mediator, INavigationService navigationService)
        : base(mediator, navigationService)
    {
    }

    public override string HeaderText => "Products";
}