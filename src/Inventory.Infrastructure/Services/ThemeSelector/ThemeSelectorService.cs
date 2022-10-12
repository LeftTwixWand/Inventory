using CommunityToolkit.WinUI.Helpers;
using Inventory.Application.Services.ThemeSelector;
using Inventory.Presentation.Helpers;
using Microsoft.UI.Xaml;

namespace Inventory.Infrastructure.Services.ThemeSelector;

public class ThemeSelectorService : IThemeSelectorService
{
    private const string SettingsKey = "AppBackgroundRequestedTheme";

    private readonly ApplicationDataStorageHelper _applicationDataStorage;
    private readonly Window _window;

    public ThemeSelectorService(ApplicationDataStorageHelper applicationDataStorage, Window window)
    {
        _applicationDataStorage = applicationDataStorage;
        _window = window;
    }

    public ElementTheme Theme { get; set; } = ElementTheme.Default;

    public void Initialize()
    {
        Theme = LoadThemeFromSettingsAsync();
    }

    public void SetTheme(ElementTheme theme)
    {
        Theme = theme;

        SetRequestedTheme();
        SaveThemeInSettingsAsync(Theme);
    }

    public void SetRequestedTheme()
    {
        if (_window.Content is FrameworkElement rootElement)
        {
            rootElement.RequestedTheme = Theme;

            TitleBarHelper.UpdateTitleBar(Theme, _window);
        }
    }

    private ElementTheme LoadThemeFromSettingsAsync()
    {
        if (_applicationDataStorage.TryRead<string>(SettingsKey, out var themeName))
        {
            if (Enum.TryParse(themeName, out ElementTheme cacheTheme))
            {
                return cacheTheme;
            }
        }

        return ElementTheme.Default;
    }

    private void SaveThemeInSettingsAsync(ElementTheme theme)
    {
        _applicationDataStorage.Save(SettingsKey, theme.ToString());
    }
}