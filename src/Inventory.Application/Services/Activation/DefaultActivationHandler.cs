using System.Threading.Tasks;
using BuildingBlocks.Application.Services.Activation.Handlers;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.Dashboard;
using Microsoft.UI.Xaml;

namespace Inventory.Application.Services.Activation;

public sealed class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService _navigationService;

    public DefaultActivationHandler(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs? args)
    {
        // None of the ActivationHandlers has handled the activation.
        return _navigationService.Frame?.Content == null;
    }

    protected override async Task HandleInternalAsync(LaunchActivatedEventArgs? args)
    {
        _navigationService.NavigateTo(typeof(DashboardViewModel).FullName!, args?.Arguments);

        await Task.CompletedTask;
    }
}