using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.DashboardViewModels;
using Inventory.Application.ViewModels.MainViewModels;
using Inventory.Application.ViewModels.ProductsViewModels;
using Inventory.Application.ViewModels.ProductViewModels;
using Inventory.Presentation.Views.DashboardViews;
using Inventory.Presentation.Views.MainViews;
using Inventory.Presentation.Views.ProductsViews;
using Inventory.Presentation.Views.ProductViews;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Services.Navigation;

internal class ViewsService : IViewsService
{
    private readonly Dictionary<string, Type> _pages = new();

    public ViewsService()
    {
        Configure<MainViewModel, MainView>();
        Configure<ProductsViewModel, ProductsView>();
        Configure<ProductViewModel, ProductView>();
        Configure<DashboardViewModel, DashboardView>();
    }

    public Type GetViewType(string key)
    {
        Type? viewType;
        lock (_pages)
        {
            if (!_pages.TryGetValue(key, out viewType))
            {
                throw new ArgumentException($"Page not found: {key}. Register the view in the constructor.");
            }
        }

        return viewType;
    }

    public void Configure<TViewModel, TView>()
        where TViewModel : ObservableObject
        where TView : Page
    {
        lock (_pages)
        {
            var key = typeof(TViewModel).FullName ?? string.Empty;

            if (_pages.ContainsKey(key))
            {
                throw new ArgumentException($"The key {key} is already configured in PageService");
            }

            var type = typeof(TView);
            if (_pages.Any(page => page.Value == type))
            {
                throw new ArgumentException($"This type is already configured with key {_pages.First(p => p.Value == type).Key}");
            }

            _pages.Add(key, type);
        }
    }
}