using Autofac;
using BuildingBlocks.Application.Services.Activation.Handlers;
using Inventory.Application.Services.Activation;
using Inventory.Application.Services.Activation.Handlers;
using Inventory.Services.Activation;
using Microsoft.UI.Xaml;

namespace Inventory.AutofacModules;

public sealed class ActivationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ActivationService>().As<IActivationService>().InstancePerLifetimeScope();

        builder.RegisterType<DefaultActivationHandler>().As<ActivationHandler<LaunchActivatedEventArgs>>().InstancePerDependency();
    }
}