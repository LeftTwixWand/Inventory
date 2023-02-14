using Inventory.Presentation.Common;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace Inventory.Presentation.Controls.Section;

internal sealed class Section : ContentControl
{
    private Border? container;
    private Grid? content;
    private Button? button;

    public Section()
    {
        DefaultStyleKey = typeof(Section);
    }

    private event RoutedEventHandler? HeaderButtonClick;

    public object Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(nameof(Header), typeof(object), typeof(Section), new PropertyMetadata(null, HeaderChanged));

    private static void HeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as Section;
        control?.UpdateControl();
    }

    public DataTemplate HeaderTemplate
    {
        get => (DataTemplate)GetValue(HeaderTemplateProperty);
        set => SetValue(HeaderTemplateProperty, value);
    }

    public static readonly DependencyProperty HeaderTemplateProperty =
        DependencyProperty.Register(nameof(HeaderTemplate), typeof(DataTemplate), typeof(Section), new PropertyMetadata(null));

    public string HeaderButtonGlyph
    {
        get => (string)GetValue(HeaderButtonGlyphProperty);
        set => SetValue(HeaderButtonGlyphProperty, value);
    }

    private static void HeaderButtonGlyphChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as Section;
        control?.UpdateControl();
    }

    public static readonly DependencyProperty HeaderButtonGlyphProperty = DependencyProperty.Register(nameof(HeaderButtonGlyph), typeof(string), typeof(Section), new PropertyMetadata(null, HeaderButtonGlyphChanged));

    public string HeaderButtonLabel
    {
        get => (string)GetValue(HeaderButtonLabelProperty);
        set => SetValue(HeaderButtonLabelProperty, value);
    }

    private static void HeaderButtonLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as Section;
        control?.UpdateControl();
    }

    public static readonly DependencyProperty HeaderButtonLabelProperty = DependencyProperty.Register(nameof(HeaderButtonLabel), typeof(string), typeof(Section), new PropertyMetadata(null, HeaderButtonLabelChanged));

    public bool IsButtonVisible
    {
        get => (bool)GetValue(IsButtonVisibleProperty);
        set => SetValue(IsButtonVisibleProperty, value);
    }

    private static void IsButtonVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as Section;
        control?.UpdateControl();
    }

    public static readonly DependencyProperty IsButtonVisibleProperty = DependencyProperty.Register(nameof(IsButtonVisible), typeof(bool), typeof(Section), new PropertyMetadata(true, IsButtonVisibleChanged));

    public object Footer
    {
        get => GetValue(FooterProperty);
        set => SetValue(FooterProperty, value);
    }

    public static readonly DependencyProperty FooterProperty = DependencyProperty.Register(nameof(Footer), typeof(object), typeof(Section), new PropertyMetadata(null));

    public DataTemplate FooterTemplate
    {
        get => (DataTemplate)GetValue(FooterTemplateProperty);
        set => SetValue(FooterTemplateProperty, value);
    }
    public bool OnIsEnabledChanged { get; private set; }

    public static readonly DependencyProperty FooterTemplateProperty = DependencyProperty.Register(nameof(FooterTemplate), typeof(DataTemplate), typeof(Section), new PropertyMetadata(null));


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

    public void UpdateContainer()
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

    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        container = GetTemplateChild(nameof(container)) as Border;
        content = GetTemplateChild(nameof(content)) as Grid;
        button = GetTemplateChild(nameof(button)) as Button;

        if (button is not null)
        {
            button.Click += OnClick;
        }

        IsEnabledChanged += OnIsEnabledChanged; ;
    }

    private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void OnClick(object sender, RoutedEventArgs e)
    {
        HeaderButtonClick ?.Invoke(this, e);
    }

}
