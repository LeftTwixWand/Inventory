using System.Collections.Generic;
using Inventory.Application.Orders.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.DashboardViews.Panes;

public sealed partial class OrdersPane : UserControl
{
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IList<OrderModel>), typeof(OrdersPane), new PropertyMetadata(0));

    public OrdersPane()
    {
        InitializeComponent();
    }

    public IList<OrderModel> ItemsSource
    {
        get { return (IList<OrderModel>)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
}