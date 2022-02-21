namespace BuildingBlocks.Application.Services.DatabaseMigration;

public interface IDatabaseMigrationService
{
    Task MigrateAsync();
}