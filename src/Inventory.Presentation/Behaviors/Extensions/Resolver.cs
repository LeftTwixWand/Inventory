using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Presentation.Behaviors.Extensions;


public sealed class Resolver : MarkupExtension
{
    protected override object ProvideValue(IXamlServiceProvider serviceProvider)
    {
        return base.ProvideValue(serviceProvider);
    }
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var provideValueTarget = serviceProvider.GetService<
            .GetService(typeof(IProvideValueTarget));

        // Find the type of the property we are resolving
        var targetProperty = provideValueTarget.TargetProperty as PropertyInfo;

        if (targetProperty == null)
        {
            throw new InvalidProgramException();
        }

        // Find the implementation of the type in the container
        return BootStrapper.Container.Resolve(targetProperty.PropertyType);
    }
}
//https://stackoverflow.com/questions/33097460/clean-way-to-injecting-dependency-to-wpf-behavior