using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.Product;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.Product;

public sealed partial class ProductView : Page
{
    public ProductView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<ProductViewModel>();
    }

    private ProductViewModel ViewModel { get; }
}