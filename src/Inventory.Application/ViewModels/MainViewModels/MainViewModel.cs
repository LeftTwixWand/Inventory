using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HarabaSourceGenerators.Common.Attributes;
using Inventory.Application.Products.CreateNewProduct;
using MediatR;

namespace Inventory.Application.ViewModels.MainViewModels;

[Inject]
public partial class MainViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    [ObservableProperty]
    private string buttonText = "Click me";

    [ICommand]
    private void ChangeText()
    {
        _mediator.Send(new CreateNewProductCommand("My name"));
        _mediator.Send(new CreateNewProductWithResultCommand("My name"));
    }
}