using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HarabaSourceGenerators.Common.Attributes;
using Inventory.Application.Products.CreateNewProduct;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.BaseViewModels;
using MediatR;

namespace Inventory.Application.ViewModels.MainViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private string buttonText = "Click me";

    public MainViewModel(IMediator mediator, INavigationService navigationService) : base(mediator, navigationService)
    {
    }

    public override string HeaderText => base.HeaderText;

    [ICommand]
    private void ChangeText()
    {
        _mediator.Send(new CreateNewProductCommand("My name"));
        _mediator.Send(new CreateNewProductWithResultCommand("My name"));
    }
}