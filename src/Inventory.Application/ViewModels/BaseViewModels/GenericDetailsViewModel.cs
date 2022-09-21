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

    [RelayCommand]
    protected abstract Task Edit();

    [RelayCommand]
    protected abstract Task Delete();

    [RelayCommand]
    protected abstract Task Save();

    [RelayCommand]
    protected abstract Task Cancel();
}