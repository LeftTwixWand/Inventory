using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Services.Navigation;
using MediatR;

namespace Inventory.Application.ViewModels.BaseViewModels;

public abstract partial class GenericDetailsViewModel<TModel> : BaseViewModel
    where TModel : ObservableObject
{
    [ObservableProperty]
    private TModel? item;

    [ObservableProperty]
    private TModel? editableItem;

    [ObservableProperty]
    private bool isEditMode;

    public GenericDetailsViewModel(IMediator mediator, INavigationService navigationService)
        : base(mediator, navigationService)
    {
    }

    [ICommand]
    protected abstract Task Edit();

    [ICommand]
    protected abstract Task Delete();

    [ICommand]
    protected abstract Task Save();

    [ICommand]
    protected abstract Task Cancel();
}