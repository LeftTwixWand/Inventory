using System.Collections.Generic;
using Inventory.Application.Customers.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.DashboardViews.Panes;

public sealed partial class CustomerPane : UserControl
{
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IList<CustomerModel>), typeof(CustomerPane), new PropertyMetadata(0));

    public CustomerPane()
    {
        InitializeComponent();
    }

    public IList<CustomerModel> ItemsSource
    {
        get { return (IList<CustomerModel>)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
}