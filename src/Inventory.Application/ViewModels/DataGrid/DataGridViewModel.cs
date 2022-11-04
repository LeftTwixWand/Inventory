using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Models;
using Inventory.Application.Services.Navigation;
using Inventory.Application.Services.SampleData;

namespace Inventory.Application.ViewModels.DataGrid;

public class DataGridViewModel : ObservableObject, INavigatedTo
{
    private readonly ISampleDataService _sampleDataService;

    public DataGridViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

    public async void OnNavigatedTo(object _)
    {
        Source.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetGridDataAsync();

        foreach (var item in data)
        {
            Source.Add(item);
        }
    }
}