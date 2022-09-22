using Inventory.Application.ViewModels.ContentGrid;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views;

public sealed partial class ContentGridPage : Page
{
    public ContentGridPage(ContentGridViewModel contentGridViewModel)
    {
        ViewModel = contentGridViewModel;
        InitializeComponent();
    }

    public ContentGridViewModel ViewModel { get; }
}