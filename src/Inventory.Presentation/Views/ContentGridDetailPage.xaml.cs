using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.WinUI.UI.Animations;
using Inventory.Application.ViewModels.ContentGrid;

using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace Inventory.Presentation.Views;

public sealed partial class ContentGridDetailPage : Page
{
    public ContentGridDetailPage()
    {
        ViewModel = Ioc.Default.GetRequiredService<ContentGridDetailViewModel>();
        InitializeComponent();
    }

    public ContentGridDetailViewModel ViewModel { get; }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        this.RegisterElementForConnectedAnimation("animationKeyContentGrid", itemHero);
    }

    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            if (ViewModel.Item != null)
            {
                ViewModel.NavigationService.SetListDataItemForNextConnectedAnimation(ViewModel.Item);
            }
        }
    }
}