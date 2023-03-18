using System;
using CommunityToolkit.Diagnostics;
using Microsoft.UI.Xaml.Data;

namespace Inventory.Presentation.Converters;

internal sealed class InvertBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool valueToInver)
        {
            return !valueToInver;
        }

        ThrowHelper.ThrowArgumentException(nameof(value), $"Value has to be of type {typeof(bool)}");
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is bool valueToInver)
        {
            return !valueToInver;
        }

        ThrowHelper.ThrowArgumentException(nameof(value), $"Value has to be of type {typeof(bool)}");
        return null;
    }
}