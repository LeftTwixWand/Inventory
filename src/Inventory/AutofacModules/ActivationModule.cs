using Autofac;
using BuildingBlocks.Application.Services.Activation.Handlers;
using Inventory.Application.Services.Activation;
using Inventory.Application.Services.Activation.Handlers;
using Inventory.Application.Services.ThemeSelector;
using Inventory.Services.Activation;
using Inventory.Services.ThemeSelector;
using Microsoft.UI.Xaml;

namespace Inventory.AutofacModules;

public sealed class ActivationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ActivationService>().As<IActivationService>().InstancePerLifetimeScope();

        builder.RegisterType<DefaultActivationHandler>().As<ActivationHandler<LaunchActivatedEventArgs>>().InstancePerDependency();
        builder.RegisterType<ThemeSelectorService>().As<IThemeSelectorService>().InstancePerLifetimeScope();
    }
}