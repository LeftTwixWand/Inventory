using System;
using Autofac;
using Serilog;
using Serilog.Formatting.Compact;
using Windows.Storage;

namespace Inventory.AutofacModules;

internal sealed class LoggingModule : Module
{
    private const string LogFileName = "logs.json";

    protected override void Load(ContainerBuilder builder)
    {
        var logger = CreateLogger();

        builder.RegisterInstance(logger).As<ILogger>().SingleInstance();
    }

    private static ILogger CreateLogger()
    {
        var file = ApplicationData.Current.LocalFolder.CreateFileAsync(LogFileName, CreationCollisionOption.OpenIfExists).GetAwaiter().GetResult();

        return new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Debug(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Context}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(new CompactJsonFormatter(), file.Path)
            .CreateLogger();
    }
}