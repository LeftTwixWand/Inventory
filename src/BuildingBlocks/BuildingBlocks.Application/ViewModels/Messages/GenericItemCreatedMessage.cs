using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BuildingBlocks.Application.ViewModels.Messages;

public sealed class GenericItemCreatedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemCreatedMessage(TModel value)
        : base(value)
    {
    }
}