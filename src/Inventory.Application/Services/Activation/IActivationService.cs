using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace Inventory.Application.Services.Activation;

public interface IActivationService
{
    Task ActivateAsync(UIElement shellView, object activationArgs);
}