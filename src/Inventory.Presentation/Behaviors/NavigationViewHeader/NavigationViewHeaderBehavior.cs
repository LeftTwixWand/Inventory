using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.Application.Services.Navigation;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Xaml.Interactivity;

namespace Inventory.Presentation.Behaviors.NavigationViewHeader;

/// <summary>
/// Allows to collaps navigation view header from the page code:
/// <code>
/// xmlns:behaviors="using:Inventory.Presentation.Behaviors.NavigationViewHeader"
/// behaviors:NavigationViewHeaderBehavior.HeaderMode="Never"
/// </code>
/// <para>NOTE: Tha bahaviour class has to be public.</para>
/// </summary>
public class NavigationViewHeaderBehavior : Behavior<NavigationView>
{
    public static readonly DependencyProperty DefaultHeaderProperty = DependencyProperty.Register(nameof(DefaultHeader), typeof(object), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, UpdateHeaderCallback));

    public static readonly DependencyProperty HeaderModeProperty = DependencyProperty.RegisterAttached("HeaderMode", typeof(bool), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(NavigationViewHeaderMode.Always, UpdateHeaderCallback));

    public static readonly DependencyProperty HeaderContextProperty = DependencyProperty.RegisterAttached("HeaderContext", typeof(object), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, UpdateHeaderCallback));

    public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.RegisterAttached("HeaderTemplate", typeof(DataTemplate), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, UpdateHeaderTemplateCallback));

    private static NavigationViewHeaderBehavior? _current;

    private Page? _currentPage;

    public DataTemplate? DefaultHeaderTemplate { get; set; }

    public object DefaultHeader
    {
        get => GetValue(DefaultHeaderProperty);
        set => SetValue(DefaultHeaderProperty, value);
    }

    public static NavigationViewHeaderMode GetHeaderMode(Page page)
    {
        return (NavigationViewHeaderMode)page.GetValue(HeaderModeProperty);
    }

    public static void SetHeaderMode(Page page, NavigationViewHeaderMode value)
    {
        page.SetValue(HeaderModeProperty, value);
    }

    public static object GetHeaderContext(Page page)
    {
        return page.GetValue(HeaderContextProperty);
    }

    public static void SetHeaderContext(Page page, object value)
    {
        page.SetValue(HeaderContextProperty, value);
    }

    public static DataTemplate GetHeaderTemplate(Page page)
    {
        return (DataTemplate)page.GetValue(HeaderTemplateProperty);
    }

    public static void SetHeaderTemplate(Page page, DataTemplate value)
    {
        page.SetValue(HeaderTemplateProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();
        _current = this;
        var navigationService = Ioc.Default.GetRequiredService<INavigationService>();
        navigationService.Navigated += OnNavigated;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        var navigationService = Ioc.Default.GetRequiredService<INavigationService>();
        navigationService.Navigated -= OnNavigated;
    }

    private static void UpdateHeaderCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        _current?.UpdateHeader();
    }

    private static void UpdateHeaderTemplateCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        _current?.UpdateHeaderTemplate();
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        var frame = sender as Frame;
        if (frame?.Content is Page page)
        {
            _currentPage = page;

            UpdateHeader();
            UpdateHeaderTemplate();
        }
    }

    private void UpdateHeader()
    {
        if (_currentPage is not null)
        {
            var headerMode = GetHeaderMode(_currentPage);
            if (headerMode == NavigationViewHeaderMode.Never)
            {
                AssociatedObject.Header = null;
                AssociatedObject.AlwaysShowHeader = false;
            }
            else
            {
                var headerFromPage = GetHeaderContext(_currentPage);
                if (headerFromPage is not null)
                {
                    AssociatedObject.Header = headerFromPage;
                }
                else
                {
                    AssociatedObject.Header = DefaultHeader;
                }

                if (headerMode == NavigationViewHeaderMode.Always)
                {
                    AssociatedObject.AlwaysShowHeader = true;
                }
                else
                {
                    AssociatedObject.AlwaysShowHeader = false;
                }
            }
        }
    }

    private void UpdateHeaderTemplate()
    {
        if (_currentPage is not null)
        {
            var headerTemplate = GetHeaderTemplate(_currentPage);
            AssociatedObject.HeaderTemplate = headerTemplate ?? DefaultHeaderTemplate;
        }
    }
}