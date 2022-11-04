using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Services.Navigation;

namespace Inventory.Application.ViewModels.Dashboard;

public sealed partial class DashboardViewModel : ObservableObject, INavigatedTo<string>
{
    [ObservableProperty]
    private string myText = "myText";

    public void OnNavigatedTo(string parameter)
    {
        throw new System.NotImplementedException();
    }
}