using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.ViewModels.ContentGrid;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views;

public sealed partial class ContentGridPage : Page
{
    public ContentGridPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<ContentGridViewModel>();
        InitializeComponent();
    }

    public ContentGridViewModel ViewModel { get; }
}