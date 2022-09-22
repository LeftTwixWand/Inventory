namespace Inventory.Infrastructure.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
