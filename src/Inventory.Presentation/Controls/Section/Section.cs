using Inventory.Presentation.Common;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Controls.Section;

internal sealed class Section : ContentControl
{
    internal static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(object), typeof(Section), new PropertyMetadata(null, HeaderChanged));

    internal static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register(nameof(HeaderTemplate), typeof(DataTemplate), typeof(Section), new PropertyMetadata(null));

    internal static readonly DependencyProperty HeaderButtonGlyphProperty = DependencyProperty.Register(nameof(HeaderButtonGlyph), typeof(string), typeof(Section), new PropertyMetadata(null, HeaderButtonGlyphChanged));

    internal static readonly DependencyProperty HeaderButtonLabelProperty = DependencyProperty.Register(nameof(HeaderButtonLabel), typeof(string), typeof(Section), new PropertyMetadata(null, HeaderButtonLabelChanged));

    internal static readonly DependencyProperty IsButtonVisibleProperty = DependencyProperty.Register(nameof(IsButtonVisible), typeof(bool), typeof(Section), new PropertyMetadata(true, IsButtonVisibleChanged));

    internal static readonly DependencyProperty FooterProperty = DependencyProperty.Register(nameof(Footer), typeof(object), typeof(Section), new PropertyMetadata(null));

    internal static readonly DependencyProperty FooterTemplateProperty = DependencyProperty.Register(nameof(FooterTemplate), typeof(DataTemplate), typeof(Section), new PropertyMetadata(null));

    private Border? container;
    private Grid? content;
    private Button? button;

    internal Section()
    {
        DefaultStyleKey = typeof(Section);
    }

    private event RoutedEventHandler? HeaderButtonClick;

    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public DataTemplate HeaderTemplate
    {
        get => (DataTemplate)GetValue(HeaderTemplateProperty);
        set => SetValue(HeaderTemplateProperty, value);
    }

    public string HeaderButtonGlyph
    {
        get => (string)GetValue(HeaderButtonGlyphProperty);
        set => SetValue(HeaderButtonGlyphProperty, value);
    }

    public string HeaderButtonLabel
    {
        get => (string)GetValue(HeaderButtonLabelProperty);
        set => SetValue(HeaderButtonLabelProperty, value);
    }

    public bool IsButtonVisible
    {
        get => (bool)GetValue(IsButtonVisibleProperty);
        set => SetValue(IsButtonVisibleProperty, value);
    }

    public object Footer
    {
        get => GetValue(FooterProperty);
        set => SetValue(FooterProperty, value);
    }

    public DataTemplate FooterTemplate
    {
        get => (DataTemplate)GetValue(FooterTemplateProperty);
        set => SetValue(FooterTemplateProperty, value);
    }

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        container = GetTemplateChild(nameof(container)) as Border;
        content = GetTemplateChild(nameof(content)) as Grid;
        button = GetTemplateChild(nameof(button)) as Button;

        if (button is not null)
        {
            button.Click += Button_Click; ;
        }

        IsEnabledChanged += Section_IsEnabledChanged; ;
    }

    private static void HeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as Section;
        control?.UpdateControl();
    }

    private static void HeaderButtonGlyphChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as Section;
        control?.UpdateControl();
    }

    private static void HeaderButtonLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as Section;
        control?.UpdateControl();
    }

    private static void IsButtonVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as Section;
        control?.UpdateControl();
    }

    private void UpdateControl()
    {
        if (content is null)
        {
            return;
        }

        content.RowDefinitions[0].Height = Header is null ? GridLengths.Zero : GridLength.Auto;
        content.RowDefinitions[2].Height = Footer is null ? GridLengths.Zero : GridLength.Auto;

        if (button is not null)
        {
            button.Visibility = IsButtonVisible && !string.IsNullOrEmpty($"{HeaderButtonGlyph}{HeaderButtonLabel}") ? Visibility.Visible : Visibility.Collapsed;
        }

        UpdateContainer();
    }

    private void UpdateContainer()
    {
        if (content is null)
        {
            return;
        }

        if (IsEnabled)
        {
            // container.ClearEffects();
            content.Opacity = 1.0;
        }
        else
        {
            // container.Grayscale();
            content.Opacity = 0.5;
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        HeaderButtonClick?.Invoke(this, e);
    }

    private void Section_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        UpdateContainer();
    }
}
