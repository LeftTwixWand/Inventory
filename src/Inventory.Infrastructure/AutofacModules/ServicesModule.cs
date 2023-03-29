using Autofac;
using BuildingBlocks.Domain.UnitOfWorks;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;
using CommunityToolkit.Mvvm.Messaging;
using Inventory.Application.Services.ThemeSelector;
using Inventory.Infrastructure.Services.ThemeSelector;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // builder.RegisterInstance(new ApplicationDataStorageHelper(ApplicationData.Current)).SingleInstance();

        builder.RegisterType<DomainEventsDispatcher>().As<IDomainEventsDispatcher>().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<ThemeSelectorService>().As<IThemeSelectorService>().SingleInstance();
        builder.RegisterInstance<IMessenger>(WeakReferenceMessenger.Default).SingleInstance();
    }
}