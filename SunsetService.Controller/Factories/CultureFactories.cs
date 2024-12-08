using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace SolarCalculator.Service.Factories;

public class CultureQueryStringValueProviderFactory : IValueProviderFactory
{
    public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var query = context.ActionContext.HttpContext.Request.Query;
        if (query?.Count > 0)
        {
            context.ValueProviders.Add(
                new QueryStringValueProvider(
                    BindingSource.Query,
                    query,
                    CultureInfo.CurrentCulture));
        }

        return Task.CompletedTask;
    }
}

public class CultureRouteValueProviderFactory : IValueProviderFactory
{
    public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        context.ValueProviders.Add(
            new RouteValueProvider(
                BindingSource.Path,
                context.ActionContext.RouteData.Values,
                CultureInfo.CurrentCulture));

        return Task.CompletedTask;
    }
}