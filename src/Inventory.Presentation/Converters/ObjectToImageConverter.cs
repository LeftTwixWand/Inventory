using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;

namespace Inventory.Presentation.Converters;

public sealed class ObjectToImageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is null)
        {
            return new BitmapImage(new Uri("ms-appx:///Inventory.Presentation/Assets/Icons/Customers.png"));
        }

        if (value is byte[] bytes)
        {
            return ImageFromBytes(bytes).GetAwaiter().GetResult();
        }

        throw new NotSupportedException("The current value type in sot supported");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }

    private static async Task<BitmapImage> ImageFromBytes(byte[] bytes)
    {
        BitmapImage image = new();

        using var stream = new InMemoryRandomAccessStream();

        await stream.WriteAsync(bytes.AsBuffer());

        stream.Seek(0);

        await image.SetSourceAsync(stream);

        return image;
    }
}