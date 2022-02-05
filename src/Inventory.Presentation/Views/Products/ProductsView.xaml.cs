using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.ProductsViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.Products;

public sealed partial class ProductsView : UserControl
{
    public ProductsView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<ProductsViewModel>();
    }

    public ProductsViewModel ViewModel { get; private set; }
}