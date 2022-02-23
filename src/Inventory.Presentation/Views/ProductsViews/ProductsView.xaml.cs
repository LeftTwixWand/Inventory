using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.ProductsViewModels;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.ProductsViews;

public sealed partial class ProductsView : Page
{
    public ProductsView()
    {
        ViewModel = Ioc.Default.GetRequiredService<ProductsViewModel>();
        InitializeComponent();
    }

    public ProductsViewModel ViewModel { get; }
}