using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.Services.SampleData;

namespace Inventory.Application.ViewModels.ListDetails;

public sealed partial class ListDetailsViewModel : ObservableObject, INavigatedTo
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? _selected;

    public ListDetailsViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

    public async void OnNavigatedTo(object _)
    {
        SampleItems.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetListDetailsDataAsync();

        foreach (var item in data)
        {
            SampleItems.Add(item);
        }
    }

    public void EnsureItemSelected()
    {
        Selected ??= SampleItems.First();
    }
}