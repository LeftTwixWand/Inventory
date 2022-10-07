using Autofac;
using BuildingBlocks.Application.Services.Activation.Handlers;
using Inventory.Application.Services.Activation;
using Inventory.Infrastructure.AutofacModules.Helpers;
using Inventory.Infrastructure.Services.Activation;

namespace Inventory.Infrastructure.AutofacModules;

public sealed class ActivationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ActivationService>().As<IActivationService>().InstancePerLifetimeScope();

        // Register all the activation handlers automatically
        builder
            .RegisterAssemblyTypes(ExternalAssemblies.ApplicationLayer)
            .AsClosedTypesOf(typeof(IActivationHandler))
            .AsImplementedInterfaces()
            .InstancePerDependency();

        // Register all the generic activation handlers automatically
        builder
            .RegisterAssemblyTypes(ExternalAssemblies.ApplicationLayer)
            .AsClosedTypesOf(typeof(ActivationHandler<>))
            .AsImplementedInterfaces()
            .InstancePerDependency();
    }
}