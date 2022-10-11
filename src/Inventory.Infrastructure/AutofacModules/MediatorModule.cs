using Autofac;
using FluentValidation;
using Inventory.Infrastructure.AutofacModules.Helpers;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterMediatR(ExternalAssemblies.ApplicationLayer);

        var openHandlerTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(INotificationHandler<>),
            typeof(IStreamRequestHandler<,>),
            typeof(IValidator<>),
        };

        foreach (var openHandlerType in openHandlerTypes)
        {
            builder.RegisterAssemblyTypes(ExternalAssemblies.ApplicationLayer)
                .AsClosedTypesOf(openHandlerType)
                .AsImplementedInterfaces();
        }
    }
}