using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.ProductViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.ProductViews.Cards;

public sealed partial class ProductCard : UserControl
{
    public ProductCard()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<ProductViewModel>();
    }

    public ProductViewModel ViewModel { get; private set; }
}