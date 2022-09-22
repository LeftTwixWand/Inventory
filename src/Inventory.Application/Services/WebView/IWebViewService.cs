using System;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;

namespace Inventory.Application.Services.WebView;

public interface IWebViewService
{
    event EventHandler<CoreWebView2WebErrorStatus>? NavigationCompleted;

    Uri? Source { get; }

    bool CanGoBack { get; }

    bool CanGoForward { get; }

    void Initialize(WebView2 webView);

    void GoBack();

    void GoForward();

    void Reload();

    void UnregisterEvents();
}