using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;

namespace Inventory.Application.Helpers;

internal static class ImageConverter
{
    public static async Task<BitmapImage?> GetBitmapAsync(byte[]? data)
    {
        if (data is null)
        {
            return null;
        }

        var bitmapImage = new BitmapImage();

        using (var stream = new InMemoryRandomAccessStream())
        {
            using (var writer = new DataWriter(stream))
            {
                writer.WriteBytes(data);
                await writer.StoreAsync();
                await writer.FlushAsync();
                writer.DetachStream();
            }

            stream.Seek(0);
            await bitmapImage.SetSourceAsync(stream);
        }

        return bitmapImage;
    }

    public static async Task<List<ImageSource?>> CreateImageSources(List<byte[]> imagesData)
    {
        List<ImageSource?> imageSources = new();

        foreach (var item in imagesData)
        {
            imageSources.Add(await GetImageSourceAsync(item));
        }

        return imageSources;
    }

    private static async Task<ImageSource?> GetImageSourceAsync(byte[] data)
    {
        return await GetBitmapAsync(data);
    }
}