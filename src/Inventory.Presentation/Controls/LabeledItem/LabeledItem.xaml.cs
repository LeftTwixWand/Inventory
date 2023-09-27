using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Controls.LabeledItem;

public sealed partial class LabeledItem : UserControl
{
    public static readonly DependencyProperty CaptionProperty =
        DependencyProperty.Register(nameof(Caption), typeof(string), typeof(LabeledItem), new PropertyMetadata(default(string), OnCaptionChanged));

    public static new readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(object), typeof(LabeledItem), new PropertyMetadata(default));

    public LabeledItem()
    {
        this.InitializeComponent();
    }

    public string Caption
    {
        get => (string)GetValue(CaptionProperty);
        set => SetValue(CaptionProperty, value);
    }

    public new object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    private static void OnCaptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (LabeledItem)d;
        control.CaptionTextBlock.Text = (string)e.NewValue;
    }
}