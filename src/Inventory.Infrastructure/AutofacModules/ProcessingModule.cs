using Autofac;
using BuildingBlocks.Domain.UnitOfWorks;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;
using Inventory.Infrastructure.CQRS.Decorators.Logging;
using Inventory.Infrastructure.CQRS.Decorators.QueryDiagnostics;
using Inventory.Infrastructure.CQRS.Decorators.UnitOfWork;
using Inventory.Infrastructure.CQRS.RequestProcessors.Validation;
using MediatR;
using MediatR.Pipeline;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class ProcessingModule : Module
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