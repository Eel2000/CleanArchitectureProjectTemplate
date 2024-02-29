using CleanArchitectureProjectTemplate.Application.Interfaces.Services;
using CleanArchitectureProjectTemplate.Domain.Commons;
using CleanArchitectureProjectTemplate.Domain.Entities;

namespace CleanArchitectureProjectTemplate.Application.Services;

internal sealed class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async ValueTask<Response<IEnumerable<WeatherForecast>>> GetAsync()
    {
        var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
       .ToArray();

        await Task.Delay(500);

        return new()
        {
            Succeeded = true,
            Message = "Weather Forecast loaded",
            Data = data
        };
    }
}
