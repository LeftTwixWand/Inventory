using Inventory.Application.ViewModels.ProductViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.ProductViews.Cards;

public sealed partial class ProductCard : UserControl
{
    public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register(nameof(ViewModel), typeof(ProductViewModel), typeof(ProductCard), new PropertyMetadata(null));

    public ProductCard()
    {
        InitializeComponent();
    }

    public ProductViewModel ViewModel
    {
        get => (ProductViewModel)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }
}