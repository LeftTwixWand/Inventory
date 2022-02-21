using BuildingBlocks.Application.Services.Activation.Handlers;
using BuildingBlocks.Application.Services.DatabaseMigration;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.UI.Xaml;

namespace AxisUNO.Shared.Services.Activation.Handlers;

[Inject]
public partial class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly IDatabaseMigrationService _databaseMigrationService;

    protected override async Task HandleInternalAsync(LaunchActivatedEventArgs? args)
    {
        await _databaseMigrationService.MigrateAsync();
    }
}