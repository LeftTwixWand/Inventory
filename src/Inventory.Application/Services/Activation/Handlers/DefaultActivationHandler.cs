using BuildingBlocks.Application.Services.Activation.Handlers;
using BuildingBlocks.Application.Services.DatabaseMigration;
using HarabaSourceGenerators.Common.Attributes;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.DashboardViewModels;
using Microsoft.UI.Xaml;

namespace Inventory.Application.Services.Activation.Handlers;

[Inject]
public partial class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService _navigationService;
    private readonly IDatabaseMigrationService _databaseMigrationService;

    protected override async Task HandleInternalAsync(LaunchActivatedEventArgs? args)
    {
        _navigationService.Navigate<DashboardViewModel>(args?.Arguments);

        await _databaseMigrationService.MigrateAsync();
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs? args)
    {
        // None of the ActivationHandlers has handled the app activation
        return _navigationService.Frame.Content == null;
    }
}