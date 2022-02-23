using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Inventory.Application.AutofacModules;
using Inventory.AutofacModules;
using Inventory.Configurations.Database;
using Inventory.Database.AutofacModules;
using Inventory.Infrastructure.AutofacModules;

namespace Inventory.Configurations;

internal static class Startup
{
    internal static IServiceProvider ConfigureServices()
    {
        var builder = new ContainerBuilder();

        builder.RegisterModule<ActivationModule>();

        builder.RegisterModule<NavigationModule>();

        builder.RegisterModule<LoggingModule>();

        builder.RegisterModule<MediatorModule>();

        builder.RegisterModule<ProcessingModule>();

        builder.RegisterModule<ApplicationServicesModule>();

        builder.RegisterModule(
            new DatabaseModule(
                DatabaseConfiguration.GetOprions()));

        return new AutofacServiceProvider(builder.Build());
    }
}