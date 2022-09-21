namespace Inventory.Application.Services.ThemeSelector;

public interface IThemeSelectorService
{
    ApplicationTheme Theme { get; }

    Task InitializeAsync();

    Task SetThemeAsync(ApplicationTheme theme);

    Task SetRequestedThemeAsync();
}