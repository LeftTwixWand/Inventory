using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Controls;
using Inventory.Application.ViewModels.ListDetails;
using Inventory.Application.ViewModels.WebView;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views;

public sealed partial class ListDetailsPage : Page
{
    public ListDetailsPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<ListDetailsViewModel>();
        InitializeComponent();
    }

    public ListDetailsViewModel ViewModel { get; }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}