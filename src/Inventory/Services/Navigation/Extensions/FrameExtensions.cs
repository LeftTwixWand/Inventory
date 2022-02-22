using Microsoft.UI.Xaml.Controls;

namespace Inventory.Services.Navigation.Extensions;

internal static class FrameExtensions
{
    internal static object? GetPageViewModel(this Frame frame)
    {
        var frameContent = frame.Content;
        if (frameContent is null)
        {
            return null;
        }

        return frameContent.GetType().GetProperty("ViewModel")?.GetValue(frame.Content, null);
    }
}