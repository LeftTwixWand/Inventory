using Autofac;
using AxisUNO.Shared.Services.Activation.Handlers;
using BuildingBlocks.Application.Services.Activation.Handlers;
using Inventory.Application.Services.Activation;
using Microsoft.UI.Xaml;

namespace Inventory.Application.AutofacModules;

public sealed class ActivationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ActivationService>().As<IActivationService>().InstancePerLifetimeScope();

        builder.RegisterType<DefaultActivationHandler>().As<ActivationHandler<LaunchActivatedEventArgs>>().InstancePerDependency();
    }
}