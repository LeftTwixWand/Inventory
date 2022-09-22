using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.Services.SampleData;

namespace Inventory.Application.ViewModels.ContentGrid;

public sealed partial class ContentGridDetailViewModel : ObservableObject, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? _item;

    public ContentGridDetailViewModel(ISampleDataService sampleDataService, INavigationService navigationService)
    {
        _sampleDataService = sampleDataService;
        NavigationService = navigationService;
    }

    public INavigationService NavigationService { get; }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}