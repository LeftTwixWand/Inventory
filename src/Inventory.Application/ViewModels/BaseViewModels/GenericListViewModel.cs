using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Services.Navigation;
using MediatR;

namespace Inventory.Application.ViewModels.BaseViewModels;

public abstract partial class GenericListViewModel<TModel> : BaseViewModel
    where TModel : ObservableObject
{
    private bool multipleSelection = false;

    public GenericListViewModel(IMediator mediator, INavigationService navigationService) : base(mediator, navigationService)
    {
    }

    public TModel? SelectedItem { get; private set; } = default;

    public ObservableCollection<TModel> Items { get; private set; } = new();

    public ObservableCollection<TModel> SelectedItems { get; private set; } = new();

    [ICommand]
    protected abstract void AddNew();

    [ICommand]
    protected abstract void Refresh();

    [ICommand]
    protected abstract void DeleteSelection();
}