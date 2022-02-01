using System.Reflection;
using Inventory.Application.ViewModels.MainViewModels;

namespace Inventory.Infrastructure.AutofacModules.Helpers;

internal static class MediatorAssemblies
{
    internal static readonly Assembly ApplicationLayer = typeof(MainViewModel).Assembly;
}