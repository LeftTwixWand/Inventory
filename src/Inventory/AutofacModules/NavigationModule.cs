using Autofac;
using Inventory.Application.ViewModels.MainViewModels;

namespace Inventory.AutofacModules;

internal class NavigationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainViewModel>().InstancePerDependency();
    }
}