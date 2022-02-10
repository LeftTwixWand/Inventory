using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.ProductViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.ProductViews;

public sealed partial class ProductView : Page
{
    public ProductView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<ProductViewModel>();
    }

    public ProductViewModel ViewModel { get; private set; }
}