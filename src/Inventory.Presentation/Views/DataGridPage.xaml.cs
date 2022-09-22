using Inventory.Application.ViewModels.DataGrid;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Views;

// TODO: Change the grid as appropriate for your app. Adjust the column definitions on DataGridPage.xaml.
// For more details, see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid.
public sealed partial class DataGridPage : Page
{
    public DataGridPage(DataGridViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }

    public DataGridViewModel ViewModel { get; }
}