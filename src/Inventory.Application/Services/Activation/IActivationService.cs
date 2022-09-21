namespace Inventory.Application.Services.Activation;

/// <summary>
/// Responsible for program activation.
/// <para>Can handle different types of start parameters.</para>
/// </summary>
public interface IActivationService
{
    /// <summary>
    /// Runs activation handlers to perform the program activation.
    /// </summary>
    /// <param name="arguments">Stores information about application startup. Usually it's startup arguments.</param>
    /// <returns>Task with process of programm activation.</returns>
    Task ActivateAsync(string arguments, IServiceProvider services);
}