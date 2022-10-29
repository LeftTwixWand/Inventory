using System.Collections.ObjectModel;
using BuildingBlocks.Application.ViewModels.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BuildingBlocks.Application.ViewModels;

public abstract partial class GenericListViewModel<TModel> : ObservableRecipient,
    IRecipient<NewGenericItemCreatedMessage<TModel>>,
    IRecipient<GenericItemUpdatedMessage<TModel>>,
    IRecipient<GenericItemDeletedMessage<TModel>>
    where TModel : ObservableObject, new()
{
    public ObservableCollection<TModel> Items { get; } = new();

    public virtual void Receive(NewGenericItemCreatedMessage<TModel> message)
    {
        Items.Add(message.Value);
    }

    public virtual void Receive(GenericItemDeletedMessage<TModel> message)
    {
        Items.Remove(message.Value);
    }

    public virtual void Receive(GenericItemUpdatedMessage<TModel> message)
    {
        var itemIndex = Items.IndexOf(message.Value);
        Items[itemIndex] = message.Value;
    }

    [RelayCommand]
    protected abstract void OnCreateNewItem();
}