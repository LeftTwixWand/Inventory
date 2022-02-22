using System;
using HarabaSourceGenerators.Common.Attributes;
using Inventory.Application.Services.Navigation;
using Inventory.Services.Navigation.Extensions;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace Inventory.Configurations.Navigation;

[Inject]
public partial class NavigationService : INavigationService
{
    private readonly IViewsService _viewsService;

    private object? _lastParameterUsed;

    private Frame _frame;

    ~NavigationService()
    {
        UnregisterFrameEvents();
    }

    public event NavigatedEventHandler? Navigated;

    public bool CanGoBack
    {
        get => Frame.CanGoBack;
    }

    public Frame Frame
    {
        get
        {
            if (_frame is null)
            {
                _frame = App.MainWindow.Content as Frame ?? new Frame();
                RegisterFrameEvents();
            }

            return _frame;
        }

        set
        {
            UnregisterFrameEvents();
            _frame = value;
            RegisterFrameEvents();
        }
    }

    public bool GoBack()
    {
        if (CanGoBack)
        {
            var vmBeforeNavigation = Frame.GetPageViewModel();
            Frame.GoBack();
            if (vmBeforeNavigation is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedFrom();
            }

            return true;
        }

        return false;
    }

    public bool Navigate(Type viewModelType, object? parameter = null)
    {
        var viewModelName = viewModelType.FullName;

        if (viewModelName is null)
        {
            return false;
        }

        return Navigate(viewModelName, parameter);
    }

    public bool Navigate<TViewModel>(object? parameter = null)
    {
        var viewModelType = typeof(TViewModel);
        var viewModelName = viewModelType.FullName;

        if (viewModelName is null)
        {
            return false;
        }

        return Navigate(viewModelName, parameter);
    }

    public bool Navigate(string viewModelName, object? parameter = null)
    {
        var viewType = _viewsService.GetViewType(viewModelName);

        if (Frame.Content?.GetType() != viewType
        || (parameter is not null &&
        parameter.Equals(_lastParameterUsed) == false))
        {
            var vmBeforeNavigation = Frame.GetPageViewModel();
            var navigated = Frame.Navigate(viewType, parameter);
            if (navigated)
            {
                _lastParameterUsed = parameter;
                if (vmBeforeNavigation is INavigationAware navigationAware)
                {
                    navigationAware.OnNavigatedFrom();
                }
            }

            return navigated;
        }

        return false;
    }

    private void RegisterFrameEvents()
    {
        if (Frame is not null)
        {
            Frame.Navigated += OnNavigated;
        }
    }

    private void UnregisterFrameEvents()
    {
        if (Frame is not null)
        {
            Frame.Navigated -= OnNavigated;
        }
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (sender is Frame frame)
        {
            if (frame.GetPageViewModel() is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedTo(e.Parameter);
            }

            Navigated?.Invoke(sender, e);
        }
    }
}