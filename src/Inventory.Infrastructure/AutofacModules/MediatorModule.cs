using Autofac;
using Inventory.Infrastructure.AutofacModules.Helpers;
using Inventory.Infrastructure.CQRS.Decorators.Logging;
using Inventory.Infrastructure.CQRS.Decorators.QueryDiagnostics;
using Inventory.Infrastructure.CQRS.Decorators.UnitOfWork;
using Inventory.Infrastructure.CQRS.RequestProcessors.Validation;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR.Pipeline;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var configuration = MediatRConfigurationBuilder
           .Create(ExternalAssemblies.ApplicationLayer)
           .WithAllOpenGenericHandlerTypesRegistered()
           .Build();

        builder.RegisterMediatR(configuration);

        builder.RegisterGeneric(typeof(ValidationRequestPreProcessor<>)).As(typeof(IRequestPreProcessor<>));

        builder.RegisterGenericDecorator(typeof(UnitOfWorkCommandHandlerDecorator<>), typeof(IRequestHandler<>));
        builder.RegisterGenericDecorator(typeof(LoggingRequestHandlerDecorator<>), typeof(IRequestHandler<>));

        builder.RegisterGenericDecorator(typeof(UnitOfWorkCommandHandlerDecorator<,>), typeof(IRequestHandler<,>));
        builder.RegisterGenericDecorator(typeof(DiagnosticQueryHandlerDecorator<,>), typeof(IRequestHandler<,>));
        builder.RegisterGenericDecorator(typeof(LoggingRequestHandlerDecorator<,>), typeof(IRequestHandler<,>));
    }
}