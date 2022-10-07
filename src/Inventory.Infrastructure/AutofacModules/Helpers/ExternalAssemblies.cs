using System.Reflection;
using Inventory.Application.ViewModels.Main;

namespace Inventory.Infrastructure.AutofacModules.Helpers;

internal static class ExternalAssemblies
{
    public static readonly Assembly ApplicationLayer = typeof(MainViewModel).Assembly;
}