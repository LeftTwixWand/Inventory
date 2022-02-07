using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Products.CreateNewProduct;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.BaseViewModels;
using MediatR;

namespace Inventory.Application.ViewModels.MainViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private string buttonText = "Click me";

    public MainViewModel(IMediator mediator, INavigationService navigationService)
        : base(mediator, navigationService)
    {
    }

    public override string HeaderText => base.HeaderText;

    [ICommand]
    private void ChangeText()
    {
        Mediator.Send(new CreateNewProductCommand("My name"));
        Mediator.Send(new CreateNewProductWithResultCommand("My name"));
    }
}