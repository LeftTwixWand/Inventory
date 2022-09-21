using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Services.Navigation;
using MediatR;

namespace Inventory.Application.ViewModels.BaseViewModels;

public abstract partial class GenericCollectionViewModel<TModel> : BaseViewModel
    where TModel : ObservableObject
{
    public GenericCollectionViewModel(IMediator mediator, INavigationService navigationService)
        : base(mediator, navigationService)
    {
    }

    public TModel? SelectedItem { get; set; } = default;

    public ObservableCollection<TModel> Items { get; set; } = new();

    [RelayCommand]
    protected abstract void ItemClick();

    [RelayCommand]
    protected abstract void AddNew();

    [RelayCommand]
    protected abstract void Refresh();

    [RelayCommand]
    protected abstract void DeleteSelection();
}