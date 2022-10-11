using Autofac;
using Mapster;
using MapsterMapper;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class MappingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var config = new TypeAdapterConfig();

        builder.RegisterInstance(config);
        builder.RegisterType<ServiceMapper>().As<IMapper>().SingleInstance();
    }
}