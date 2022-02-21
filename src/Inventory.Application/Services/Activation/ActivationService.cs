using BuildingBlocks.Application.Services.Activation.Handlers;
using HarabaSourceGenerators.Common.Attributes;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Inventory.Application.Services.Activation;

[Inject]
public partial class ActivationService : IActivationService
{
    private readonly Window _mainWindow;

    private readonly ActivationHandler<LaunchActivatedEventArgs> _defaultHandler;

    private readonly IEnumerable<IActivationHandler> _activationHandlers;

    /// <inheritdoc/>
    public async Task ActivateAsync(LaunchActivatedEventArgs activationArgs)
    {
        // Initialize services that you need before the app activation.
        // Take into account that the splash screen can be shown while this code runs.
        await InitializeAsync();

        await HandleActivationAsync(activationArgs);

        // Ensure the current window is active
        _mainWindow.Activate();

        // Tasks after activation
        await StartupAsync();
    }

    private static Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    private static Task StartupAsync()
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Truing to execure DefaultActivationArgs and firs of activation handlers, that satisfy acrivation args.
    /// <para>DefaultActivationHandler will navigate to the main view.</para>
    /// </summary>
    private async Task HandleActivationAsync(LaunchActivatedEventArgs activationArgs)
    {
        if (_defaultHandler.CanHandle(activationArgs))
        {
            await _defaultHandler.HandleAsync(activationArgs);
        }

        var activationHandler = _activationHandlers.FirstOrDefault(handler => handler.CanHandle(activationArgs));

        if (activationHandler is not null)
        {
            await activationHandler.HandleAsync(activationArgs);
        }
    }
}