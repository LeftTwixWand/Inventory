using CommunityToolkit.Mvvm.Messaging.Messages;

namespace eShopOnWinUI.Presentation.ViewModels.Generic.Messages;

public sealed class GenericItemDeletedMessage<TModel> : ValueChangedMessage<TModel>
{
    public GenericItemDeletedMessage(TModel value)
        : base(value)
    {
    }
}