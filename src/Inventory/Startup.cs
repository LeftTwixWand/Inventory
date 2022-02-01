using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Inventory.AutofacModules;
using Inventory.Database.AutofacModules;
using Inventory.Infrastructure.AutofacModules;

namespace Inventory;

internal sealed class Startup
{
    internal static void Initialize()
    {
        Ioc.Default.ConfigureServices(ConfigureServices());
    }

    private static IServiceProvider ConfigureServices()
    {
        var builder = new ContainerBuilder();

        // builder.RegisterModule<ActivationModule>();

        builder.RegisterModule<NavigationModule>();

        builder.RegisterModule<LoggingModule>();

        builder.RegisterModule<MediatorModule>();

        builder.RegisterModule<ProcessingModule>();

        builder.RegisterModule<DatabaseModule>();

        return new AutofacServiceProvider(builder.Build());
    }
}