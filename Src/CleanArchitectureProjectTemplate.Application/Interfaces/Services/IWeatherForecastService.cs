using CleanArchitectureProjectTemplate.Domain.Commons;
using CleanArchitectureProjectTemplate.Domain.Entities;

namespace CleanArchitectureProjectTemplate.Application.Interfaces.Services;

public interface IWeatherForecastService
{
    ValueTask<Response<IEnumerable<WeatherForecast>>> GetAsync();
}
