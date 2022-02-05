using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Services.Navigation;
using MediatR;

namespace Inventory.Application.ViewModels.BaseViewModels;

public class BaseViewModel : ObservableObject
{
    protected readonly IMediator _mediator;
    protected readonly INavigationService _navigationService;

    public BaseViewModel(IMediator mediator, INavigationService navigationService)
    {
        _mediator = mediator;
        _navigationService = navigationService;
    }

    public virtual string HeaderText => string.Empty;
}