using System.Windows.Input;
using Inventory.Presentation.Controls.CustomCommandBars.Enums;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Presentation.Controls.CustomCommandBars;

internal sealed partial class CustomCommandBar : UserControl
{
    public static readonly DependencyProperty AddCommandProperty =
        DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(CustomCommandBar), new PropertyMetadata(0));

    public static readonly DependencyProperty CommandBarModeProperty =
        DependencyProperty.Register("CommandBarMode", typeof(CommandBarMode), typeof(CustomCommandBar), new PropertyMetadata(CommandBarMode.AddEditRemove));

    public CustomCommandBar()
    {
        InitializeComponent();
    }

    public ICommand AddCommand
    {
        get { return (ICommand)GetValue(AddCommandProperty); }
        set { SetValue(AddCommandProperty, value); }
    }

    public CommandBarMode CommandBarMode
    {
        get { return (CommandBarMode)GetValue(CommandBarModeProperty); }
        set { SetValue(CommandBarModeProperty, value); }
    }
}