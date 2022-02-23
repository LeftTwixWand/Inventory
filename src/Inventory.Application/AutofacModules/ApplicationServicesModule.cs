using Autofac;
using Inventory.Application.Services.ThemeSelector;

namespace Inventory.Application.AutofacModules;

public class ApplicationServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ThemeSelectorService>().As<IThemeSelectorService>().InstancePerDependency();

        base.Load(builder);
    }
}
