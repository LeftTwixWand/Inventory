using System.Collections.Generic;
using Inventory.Application.Products.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.DashboardViews.Panes;

public sealed partial class ProductsPane : UserControl
{
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IList<ProductModel>), typeof(ProductsPane), new PropertyMetadata(0));

    public ProductsPane()
    {
        InitializeComponent();
    }

    public IList<ProductModel> ItemsSource
    {
        get { return (IList<ProductModel>)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
}