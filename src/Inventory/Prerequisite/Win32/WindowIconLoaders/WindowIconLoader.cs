using System;
using CommunityToolkit.Diagnostics;
using Microsoft.UI.Xaml;
using PInvoke;

namespace Inventory.Prerequisite.Win32.WindowIconLoaders;

internal static class WindowIconLoader
{
    internal static void LoadIcon(this Window window, string iconPath)
    {
        Guard.IsNotNullOrEmpty(iconPath, nameof(iconPath));

        // Get the window handle
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

        // Get the icon HWND
        var hIcon = User32.LoadImage(IntPtr.Zero, iconPath, User32.ImageType.IMAGE_ICON, 16, 16, User32.LoadImageFlags.LR_LOADFROMFILE);

        // Send a message to winapi for icon change
        User32.SendMessage(hwnd, User32.WindowMessage.WM_SETICON, (IntPtr)0, hIcon);
    }
}