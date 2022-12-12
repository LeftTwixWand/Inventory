using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.WinUI.Helpers;
using Inventory.Application.Services.ThemeSelector;
using Inventory.Infrastructure.Services.ThemeSelector;
using Windows.Storage;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class ServicesModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterInstance(new ApplicationDataStorageHelper(ApplicationData.Current)).SingleInstance();

        builder.RegisterType<ThemeSelectorService>().As<IThemeSelectorService>().SingleInstance();
        builder.RegisterInstance<IMessenger>(WeakReferenceMessenger.Default).SingleInstance();
    }
}