using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.Services.SampleData;

namespace Inventory.Application.ViewModels.ContentGrid;

public sealed partial class ContentGridViewModel : ObservableObject, INavigatedTo
{
    private readonly INavigationService _navigationService;
    private readonly ISampleDataService _sampleDataService;

    public ContentGridViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
    {
        _navigationService = navigationService;
        _sampleDataService = sampleDataService;
    }

    public ObservableCollection<SampleOrder> Source { get; } = new();

    public async void OnNavigatedTo(object _)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetContentGridDataAsync();
        foreach (var item in data)
        {
            Source.Add(item);
        }
    }

    [RelayCommand]
    private void ItemClick(SampleOrder? clickedItem)
    {
        if (clickedItem != null)
        {
            _navigationService.SetListDataItemForNextConnectedAnimation(clickedItem);
            _navigationService.NavigateTo(typeof(ContentGridDetailViewModel).FullName!, clickedItem.OrderID);
        }
    }
}