using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Inventory.Application.ViewModels.MainViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string buttonText = "Click me";

    [ICommand]
    private void ChangeText()
    {
        ButtonText = "Clicked!";
    }
}