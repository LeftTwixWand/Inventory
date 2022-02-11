using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.MainViewModels;
using Inventory.Presentation.Views.DashboardViews;
using Inventory.Presentation.Views.ProductsViews;
using Inventory.Presentation.Views.ProductViews;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.MainViews;

public sealed partial class MainView : Page
{
    public MainView()
    {
        InitializeComponent();
        MainViewModel = Ioc.Default.GetRequiredService<MainViewModel>();

        frame.Navigate(typeof(DashboardView));
    }

    public MainViewModel MainViewModel { get; private set; }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        switch (args.InvokedItem.ToString())
        {
            case "Home":
                {
                    frame.Navigate(typeof(DashboardView));
                    break;
                }

            case "Products":
                {
                    frame.Navigate(typeof(ProductsView));
                    break;
                }

            case "Orders":
                {
                    frame.Navigate(typeof(ProductView));
                    break;
                }

            default:
                break;
        }
    }
}