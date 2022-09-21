using Autofac;
using BuildingBlocks.Domain.UnitOfWorks;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;
using Inventory.Infrastructure.Decorators.Logging;
using Inventory.Infrastructure.Decorators.QueryDiagnostics;
using Inventory.Infrastructure.Decorators.UnitOfWork;
using Inventory.Infrastructure.RequestProcessors.Validation;
using MediatR;
using MediatR.Pipeline;

namespace Inventory.Infrastructure.AutofacModules;

public sealed class ProcessingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DomainEventsDispatcher>().As<IDomainEventsDispatcher>().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterGeneric(typeof(ValidationRequestPreProcessor<>)).As(typeof(IRequestPreProcessor<>));

        builder.RegisterGenericDecorator(typeof(UnitOfWorkCommandHandlerDecorator<,>), typeof(IRequestHandler<,>));

        builder.RegisterGenericDecorator(typeof(DiagnosticQueryHandlerDecorator<,>), typeof(IRequestHandler<,>));

        builder.RegisterGenericDecorator(typeof(LoggingRequestHandlerDecorator<,>), typeof(IRequestHandler<,>));
    }
}