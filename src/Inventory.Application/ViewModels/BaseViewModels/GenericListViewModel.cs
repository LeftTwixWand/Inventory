using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Services.Navigation;
using MediatR;

namespace Inventory.Application.ViewModels.BaseViewModels;

public abstract partial class GenericViewModel<TModel> : BaseViewModel
    where TModel : ObservableObject
{
    public GenericViewModel(IMediator mediator, INavigationService navigationService)
        : base(mediator, navigationService)
    {
    }

    public TModel? SelectedItem { get; set; } = default;

    public ObservableCollection<TModel> Items { get; set; } = new();

    public ObservableCollection<TModel> SelectedItems { get; private set; } = new();

    [ICommand]
    protected abstract void ItemClick();

    [ICommand]
    protected abstract void AddNew();

    [ICommand]
    protected abstract void Refresh();

    [ICommand]
    protected abstract void DeleteSelection();
}