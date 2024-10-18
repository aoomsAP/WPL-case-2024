using Library.Contexts;
using Microsoft.EntityFrameworkCore;
using Project;

// Recreate & migrate the database on each run, for demo purposes

// Altered program class for doing this in MVC based on:
// https://medium.com/@ashishnimrot/extending-net-core-application-with-fake-data-seeding-in-development-environment-1c1a6eb21ff0

var host = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    })
    .Build();

using (var serviceScope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

await host.RunAsync();


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//});

//app.MapFallbackToFile("/index.html");

//app.Run();

//internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}
