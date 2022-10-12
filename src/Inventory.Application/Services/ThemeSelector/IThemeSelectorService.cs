using Microsoft.UI.Xaml;

namespace Inventory.Application.Services.ThemeSelector;

public interface IThemeSelectorService
{
    ElementTheme Theme { get; }

    void Initialize();

    void SetTheme(ElementTheme theme);

    void SetRequestedTheme();
}