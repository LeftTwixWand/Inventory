using Autofac;
using Serilog;

namespace Inventory.Infrastructure.AutofacModules;

internal sealed class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Debug(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        builder.RegisterInstance(logger).As<ILogger>().SingleInstance();
    }
}