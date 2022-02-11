using Inventory.Application.ViewModels.ProductViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.ProductViews.Details;

public sealed partial class ProductDetails : UserControl
{
    public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(ProductViewModel), typeof(ProductView), new PropertyMetadata(null));

    public ProductDetails()
    {
        InitializeComponent();
    }

    public ProductViewModel ViewModel
    {
        get => (ProductViewModel)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }
}