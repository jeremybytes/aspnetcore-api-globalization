using SunsetServices.MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(8974));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.MapGet("/SolarCalculator/{lat}/{lng}/{date}", 
    (double lat, double lng, DateTime date) =>
{
    var result = SolarCalculatorProvider.GetSolarTimes(date, lat, lng);
    return result;

})
.WithName("SunsetService");

app.Run();
