using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Services.Navigation;
using Inventory.Application.Services.WebView;

using Microsoft.Web.WebView2.Core;

namespace Inventory.Application.ViewModels.WebView;

// TODO: Review best practices and distribution guidelines for WebView2.
// https://docs.microsoft.com/microsoft-edge/webview2/get-started/winui
// https://docs.microsoft.com/microsoft-edge/webview2/concepts/developer-guide
// https://docs.microsoft.com/microsoft-edge/webview2/concepts/distribution
public sealed partial class WebViewViewModel : ObservableObject, INavigationAware
{
    // TODO: Set the default URL to display.
    [ObservableProperty]
    private Uri _source = new("https://docs.microsoft.com/windows/apps/");

    [ObservableProperty]
    private bool _isLoading = true;

    [ObservableProperty]
    private bool _hasFailures;

    public WebViewViewModel(IWebViewService webViewService)
    {
        WebViewService = webViewService;

        BrowserBackCommand = new RelayCommand(() => WebViewService.GoBack(), () => WebViewService.CanGoBack);
        BrowserForwardCommand = new RelayCommand(() => WebViewService.GoForward(), () => WebViewService.CanGoForward);
        ReloadCommand = new RelayCommand(() => WebViewService.Reload());
        OpenInBrowserCommand = new RelayCommand(async () => await Windows.System.Launcher.LaunchUriAsync(WebViewService.Source), () => WebViewService.Source != null);
    }

    public IWebViewService WebViewService
    {
        get;
    }

    public ICommand BrowserBackCommand
    {
        get;
    }

    public ICommand BrowserForwardCommand
    {
        get;
    }

    public ICommand ReloadCommand
    {
        get;
    }

    public ICommand OpenInBrowserCommand
    {
        get;
    }

    public void OnNavigatedTo(object parameter)
    {
        WebViewService.NavigationCompleted += OnNavigationCompleted;
    }

    public void OnNavigatedFrom()
    {
        WebViewService.UnregisterEvents();
        WebViewService.NavigationCompleted -= OnNavigationCompleted;
    }

    private void OnNavigationCompleted(object? sender, CoreWebView2WebErrorStatus webErrorStatus)
    {
        IsLoading = false;
        OnPropertyChanged(nameof(BrowserBackCommand));
        OnPropertyChanged(nameof(BrowserForwardCommand));
        if (webErrorStatus != default)
        {
            HasFailures = true;
        }
    }

    [RelayCommand]
    private void Retry()
    {
        HasFailures = false;
        IsLoading = true;
        WebViewService?.Reload();
    }
}