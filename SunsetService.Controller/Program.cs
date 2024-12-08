using Microsoft.AspNetCore.Mvc.ModelBinding;
using SolarCalculator.Service.Factories;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(8973));

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    var index = options.ValueProviderFactories.IndexOf(
        options.ValueProviderFactories.OfType<QueryStringValueProviderFactory>()
            .Single());

    options.ValueProviderFactories[index] =
        new CultureQueryStringValueProviderFactory();

    index = options.ValueProviderFactories.IndexOf(
        options.ValueProviderFactories.OfType<RouteValueProviderFactory>()
            .Single());

    options.ValueProviderFactories[index] =
        new CultureRouteValueProviderFactory();
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
