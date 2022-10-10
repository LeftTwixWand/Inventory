using Autofac;
using BuildingBlocks.Application.Services.Activation.Handlers;
using Inventory.Application.Services.Activation;
using Inventory.Infrastructure.Services.Activation;
using Microsoft.UI.Xaml;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class ActivationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ActivationService>().As<IActivationService>().InstancePerLifetimeScope();

        builder.RegisterType<DefaultActivationHandler>().As<ActivationHandler<LaunchActivatedEventArgs>>().InstancePerDependency();
    }
}