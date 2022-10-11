using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.Orders;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.Orders;

public sealed partial class OrdersView : Page
{
    public OrdersView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<OrdersViewModel>();
    }

    private OrdersViewModel ViewModel { get; }
}