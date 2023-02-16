using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.Products;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.Products;

public sealed partial class ProductsView : Page
{
    public ProductsView()
    {
        InitializeComponent();
    }

    private ProductsViewModel ViewModel { get; } = Ioc.Default.GetRequiredService<ProductsViewModel>();
}