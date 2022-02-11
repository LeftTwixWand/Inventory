using System;
using Microsoft.UI.Xaml.Data;

namespace Inventory.Presentation.Converters;

internal sealed class DecimalConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is decimal m)
        {
            return m == 0 ? string.Empty : m.ToString();
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value != null)
        {
            if (decimal.TryParse(value.ToString(), out decimal m))
            {
                return m;
            }
        }

        return 0m;
    }
}
