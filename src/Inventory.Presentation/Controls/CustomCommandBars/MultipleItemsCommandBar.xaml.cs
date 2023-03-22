using System.Windows.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Controls.CustomCommandBars;

internal sealed partial class MultipleItemsCommandBar : UserControl
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(MultipleItemsCommandBar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty IsSelectionModeProperty =
        DependencyProperty.Register(nameof(IsSelectionMode), typeof(bool), typeof(MultipleItemsCommandBar), new PropertyMetadata(false));

    public static readonly DependencyProperty AddCommandProperty =
        DependencyProperty.Register(nameof(AddCommand), typeof(ICommand), typeof(MultipleItemsCommandBar), new PropertyMetadata(null));

    public static readonly DependencyProperty DeleteCommandProperty =
        DependencyProperty.Register(nameof(DeleteCommand), typeof(ICommand), typeof(MultipleItemsCommandBar), new PropertyMetadata(null));

    public static readonly DependencyProperty DeleteCommandParameterProperty =
        DependencyProperty.Register(nameof(DeleteCommandParameter), typeof(object), typeof(MultipleItemsCommandBar), new PropertyMetadata(null));

    public MultipleItemsCommandBar()
    {
        InitializeComponent();
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool IsSelectionMode
    {
        get => (bool)GetValue(IsSelectionModeProperty);
        set => SetValue(IsSelectionModeProperty, value);
    }

    public ICommand AddCommand
    {
        get => (ICommand)GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public object DeleteCommandParameter
    {
        get => GetValue(DeleteCommandParameterProperty);
        set => SetValue(DeleteCommandParameterProperty, value);
    }
}