using System;
using System.Threading.Tasks;

namespace Inventory.Application.Services.Activation;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs, IServiceProvider serviceProvider);
}