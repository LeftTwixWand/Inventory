using BuildingBlocks.Application.ViewModels.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BuildingBlocks.Application.ViewModels;

public partial class GenericItemViewModel<TModel> : ObservableObject
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
    protected virtual void Save()
    {
        _messenger.Send(new NewGenericItemCreatedMessage<TModel>(item));
    }
}