using CleanArchitectureProjectTemplate.Application.Interfaces.Repositories.Base;
using CleanArchitectureProjectTemplate.Domain.Entities;

namespace CleanArchitectureProjectTemplate.Application.Interfaces.Repositories;

public interface IWeatherForecastRepository : IBaseRepository<WeatherForecast>
{
}
