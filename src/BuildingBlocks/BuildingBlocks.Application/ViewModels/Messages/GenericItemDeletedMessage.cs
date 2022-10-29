using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BuildingBlocks.Application.ViewModels.Messages;

public sealed class GenericItemDeletedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemDeletedMessage(TModel value)
        : base(value)
    {
    }
}