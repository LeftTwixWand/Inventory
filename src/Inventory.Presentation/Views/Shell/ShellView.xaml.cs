using Inventory.Application.ViewModels.Shell;
using Inventory.Presentation.Helpers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace Inventory.Presentation.Views.Shell;

public sealed partial class ShellView : Page
{
    private readonly Window _window;

    public ShellView(ShellViewModel viewModel, Window mainWindow)
    {
        ViewModel = viewModel;
        _window = mainWindow;

        InitializeComponent();

        ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.NavigationViewService.Initialize(NavigationViewControl);

        // TODO: Set the title bar icon by updating /Assets/WindowIcon.ico.
        // A custom title bar is required for full window theme and Mica support.
        // https://docs.microsoft.com/windows/apps/develop/title-bar?tabs=winui3#full-customization
        mainWindow.ExtendsContentIntoTitleBar = true;
        mainWindow.SetTitleBar(AppTitleBar);
        mainWindow.Activated += MainWindow_Activated;
    }

    public ShellViewModel ViewModel { get; }

    private void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
    {
        AppTitleBar.Margin = new Thickness()
        {
            Left = sender.CompactPaneLength * (sender.DisplayMode == NavigationViewDisplayMode.Minimal ? 2 : 1),
            Top = AppTitleBar.Margin.Top,
            Right = AppTitleBar.Margin.Right,
            Bottom = AppTitleBar.Margin.Bottom,
        };
    }

    private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
    {
        var resource = args.WindowActivationState == WindowActivationState.Deactivated ? "WindowCaptionForegroundDisabled" : "WindowCaptionForeground";

        AppTitleBarText.Foreground = (SolidColorBrush)Microsoft.UI.Xaml.Application.Current.Resources[resource];
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        TitleBarHelper.UpdateTitleBar(RequestedTheme, _window);
    }
}