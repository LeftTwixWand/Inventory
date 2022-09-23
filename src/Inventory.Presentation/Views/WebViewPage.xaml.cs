using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.WebView;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class WebViewPage : Page
{
    public WebViewPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<WebViewViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }

    public WebViewViewModel ViewModel { get; }
}