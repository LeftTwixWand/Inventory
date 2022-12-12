using System.Reflection;
using Inventory.Application.ViewModels.Shell;

namespace Inventory.Infrastructure.AutofacModules.Helpers;

internal static class ExternalAssemblies
{
    public static readonly Assembly ApplicationLayer = typeof(ShellViewModel).Assembly;
}