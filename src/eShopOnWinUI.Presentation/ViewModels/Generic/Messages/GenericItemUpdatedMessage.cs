using CommunityToolkit.Mvvm.Messaging.Messages;

namespace eShopOnWinUI.Presentation.ViewModels.Generic.Messages;

public sealed class GenericItemUpdatedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemUpdatedMessage(TModel value)
        : base(value)
    {
    }
}