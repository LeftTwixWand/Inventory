using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI;
using Inventory.Application.Services.ThemeSelector;

using Microsoft.UI.Xaml;

namespace Inventory.Application.ViewModels.Settings;

public sealed partial class SettingsViewModel : ObservableObject
{
    private readonly IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    private ElementTheme _elementTheme;

    [ObservableProperty]
    private string _versionDescription;

    public SettingsViewModel(IThemeSelectorService themeSelectorService)
    {
        _themeSelectorService = themeSelectorService;
        _elementTheme = _themeSelectorService.Theme;
        _versionDescription = GetVersionDescription();
    }

    [RelayCommand]
    private async Task SwitchTheme(ElementTheme theme)
    {
        if (ElementTheme != theme)
        {
            ElementTheme = theme;
            await _themeSelectorService.SetThemeAsync(theme);
        }
    }

    private static string GetVersionDescription()
    {
        var version = new Version(0, 1, 890, 3);

        //if (RuntimeHelper.IsMSIX)
        //{
        //    var packageVersion = Package.Current.Id.Version;

        //    version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        //}
        //else
        //{
        //    version = Assembly.GetExecutingAssembly().GetName().Version!;
        //}

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}