using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BuildingBlocks.Application.ViewModels.Messages;

public sealed class GenericItemUpdatedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemUpdatedMessage(TModel value)
        : base(value)
    {
    }
}