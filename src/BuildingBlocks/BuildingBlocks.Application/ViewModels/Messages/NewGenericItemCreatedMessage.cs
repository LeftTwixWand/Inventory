using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BuildingBlocks.Application.ViewModels.Messages;

public sealed class NewGenericItemCreatedMessage<TModel> : ValueChangedMessage<TModel>
{
    public NewGenericItemCreatedMessage(TModel value)
        : base(value)
    {
    }
}