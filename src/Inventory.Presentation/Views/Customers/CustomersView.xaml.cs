using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.Customers;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views.Customers;

public sealed partial class CustomersView : Page
{
    public CustomersView()
    {
        InitializeComponent();
        ViewModel = Ioc.Default.GetRequiredService<CustomersViewModel>();
    }

    private CustomersViewModel ViewModel { get; }
}