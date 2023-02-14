using BuildingBlocks.Application.ViewModels.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BuildingBlocks.Application.ViewModels;

public abstract partial class GenericItemViewModel<TModel> : ObservableObject
    where TModel : ObservableObject, new()
{
    private readonly IMessenger _messenger;

    [ObservableProperty]
    private TModel item = new();

    public GenericItemViewModel(IMessenger messenger)
    {
        _messenger = messenger;
    }

    [RelayCommand]
    protected virtual void Create()
    {
        _ = _messenger.Send(new GenericItemCreatedMessage<TModel>(item));
    }

    [RelayCommand]
    protected virtual void Delete()
    {
        _ = _messenger.Send(new GenericItemDeletedMessage<TModel>(item));
    }

    [RelayCommand]
    protected virtual void Update()
    {
        _ = _messenger.Send(new GenericItemUpdatedMessage<TModel>(item));
    }
}