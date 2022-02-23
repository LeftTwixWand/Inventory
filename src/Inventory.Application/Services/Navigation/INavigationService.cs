using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace Inventory.Application.Services.Navigation;

/// <summary>
/// Service, responsible for navigation in the application.
/// <para>Read more about the WinUI app navigation: <see href="https://github.com/microsoft/TemplateStudio/blob/release/docs/WinUI/navigation.md">TemplateStudio</see>.</para>
/// </summary>
public interface INavigationService
{
    event NavigatedEventHandler Navigated;

    Frame Frame { get; set; }

    /// <summary>
    /// Gets a value, indicating whether it's possible to navigate back.
    /// </summary>
    bool CanGoBack { get; }

    /// <summary>
    /// Navigate to the previous view.
    /// </summary>
    /// <returns>Navigation result.</returns>
    bool GoBack();

    /// <summary>
    /// Allows to navigete to a specific view, based on it's view model type.
    /// </summary>
    /// <param name="viewModelType">Type of view mode, that is related to some view.</param>
    /// <param name="parameter">Allows to forward additional data and handle it in the View.OnNavigatedTo event.</param>
    /// <returns>Result of navigation.</returns>
    bool Navigate(Type viewModelType, object? parameter = null);

    /// <summary>
    /// Allows to navigete to a specific view, based on it's view model type.
    /// </summary>
    /// <typeparam name="TViewModel">Type of view mode, that is related to some view.</typeparam>
    /// <param name="parameter">Allows to forward additional data and handle it in the View.OnNavigatedTo event.</param>
    /// <returns>Result of navigation.</returns>
    bool Navigate<TViewModel>(object? parameter = null);

    /// <summary>
    /// Allows to navigete to a specific view, based on it's view model full name.
    /// </summary>
    /// <param name="viewKey">Full name of the view.</param>
    /// <param name="parameter">Allows to forward additional data and handle it in the View.OnNavigatedTo event.</param>
    /// <returns>Result of navigation.</returns>
    bool Navigate(string viewKey, object? parameter = null);
}