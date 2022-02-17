using Microsoft.UI.Xaml;

namespace Inventory.Application.Services.ThemeSelector;

internal interface IThemeSelectorService
{
    ElementTheme Theme { get; }

    Task InitializeAsync();

    Task SetThemeAsync(ElementTheme theme);

    Task SetRequestedThemeAsync();
}