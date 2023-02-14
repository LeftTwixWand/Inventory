using Microsoft.UI.Xaml;

namespace Inventory.Presentation.Common;

internal static class GridLengths
{
    internal static readonly GridLength Zero = new(0);
    internal static readonly GridLength Star = new(1, GridUnitType.Star);
    internal static readonly GridLength Auto = new(1, GridUnitType.Auto);
}