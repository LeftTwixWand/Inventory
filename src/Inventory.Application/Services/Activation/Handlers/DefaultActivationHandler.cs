using BuildingBlocks.Application.Services.Activation.Handlers;
using BuildingBlocks.Application.Services.DatabaseMigration;
using Inventory.Application.Services.Navigation;
using Inventory.Application.ViewModels.DashboardViewModels;

namespace Inventory.Application.Services.Activation.Handlers;

public sealed partial class DefaultActivationHandler : IActivationHandler
{
    private readonly INavigationService _navigationService;
    private readonly IDatabaseMigrationService _databaseMigrationService;

    public DefaultActivationHandler(INavigationService navigationService, IDatabaseMigrationService databaseMigrationService)
    {
        _navigationService = navigationService;
        _databaseMigrationService = databaseMigrationService;
    }

    public bool CanHandle(object args)
    {
        return _navigationService.Frame.Content == null;
    }

    public async Task HandleAsync(object args)
    {
        _navigationService.Navigate<DashboardViewModel>();

        await _databaseMigrationService.MigrateAsync();
    }
}