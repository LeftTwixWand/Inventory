using System;
using Microsoft.UI.Xaml.Media;

namespace Inventory.Presentation.Converters;

public sealed class ObjectToImageConverter
{
    public object? Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is ImageSource imageSource)
        {
            return imageSource;
        }

        if (value is string url)
        {
            return url;
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}