using CommunityToolkit.Mvvm.Messaging.Messages;

namespace eShopOnWinUI.Presentation.ViewModels.Generic.Messages;

public sealed class GenericItemCreatedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemCreatedMessage(TModel value)
        : base(value)
    {
    }
}