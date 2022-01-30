using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.DependencyPropertyExtensions.NavigationViewItemExtensions;

/// <summary>
/// This extension class allows to specify the ViewModel for the current NavigationViewItem, and the related View will be opened.
/// <para>Usage in xaml:</para>
/// <code>
/// NavigationViewItem extensions:<see cref="NavigationExtension"/>.NavigateTo="MyApp.ViewModels.MyViewModel"
/// </code>
/// <para>winui:.</para>
/// <para>Usage in code:</para>
/// <code>
/// NavHelper.SetNavigateTo(navigationViewItem, typeof(MyViewModel).FullName);
/// </code>
/// </summary>
public class NavigationExtension
{
    // Using a DependencyProperty as the backing store for NavigateTo.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty NavigateToProperty =
        DependencyProperty.RegisterAttached("NavigateTo", typeof(string), typeof(NavigationExtension), new PropertyMetadata(null));

    public static string GetNavigateTo(NavigationViewItem obj)
    {
        return (string)obj.GetValue(NavigateToProperty);
    }

    public static void SetNavigateTo(NavigationViewItem obj, string value)
    {
        obj.SetValue(NavigateToProperty, value);
    }
}