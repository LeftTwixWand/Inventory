using CommunityToolkit.WinUI.Helpers;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.UI.Xaml;
using SystemSerializer = CommunityToolkit.Common.Helpers.SystemSerializer;

namespace Inventory.Application.Services.ThemeSelector;

[Inject]
public partial class ThemeSelectorService : IThemeSelectorService
{
    private const string SettingsKey = "ApplicationTheme";

    private readonly Window _window;

    public ElementTheme Theme { get; private set; } = ElementTheme.Default;

    public async Task InitializeAsync()
    {
        Theme = await LoadThemeFromSettingsAsync();
        await Task.CompletedTask;
    }

    public Task SetRequestedThemeAsync()
    {
        if (_window.Content is FrameworkElement root)
        {
            root.RequestedTheme = Theme;
        }

        return Task.CompletedTask;
    }

    public async Task SetThemeAsync(ElementTheme theme)
    {
        Theme = theme;

        await SetRequestedThemeAsync();
        await SaveThemeInSettingsAsync(Theme);
    }

    private static Task SaveThemeInSettingsAsync(ElementTheme theme)
    {
        var storageHelper = ApplicationDataStorageHelper.GetCurrent(new SystemSerializer());
        storageHelper.Save(SettingsKey, theme);

        return Task.CompletedTask;
    }

    private static Task<ElementTheme> LoadThemeFromSettingsAsync()
    {
        var storageHelper = ApplicationDataStorageHelper.GetCurrent(new SystemSerializer());
        var theme = storageHelper.Read(SettingsKey, @default: ElementTheme.Default);

        return Task.FromResult(theme);
    }
}