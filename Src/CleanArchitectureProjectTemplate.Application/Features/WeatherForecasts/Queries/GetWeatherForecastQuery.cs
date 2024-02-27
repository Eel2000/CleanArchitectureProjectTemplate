using CleanArchitectureProjectTemplate.Application.Interfaces.Services;
using CleanArchitectureProjectTemplate.Domain.Commons;
using CleanArchitectureProjectTemplate.Domain.Entities;
using MediatR;

namespace CleanArchitectureProjectTemplate.Application.Features.WeatherForecasts.Queries;

public sealed class GetWeatherForecastQuery : IRequest<Response<IEnumerable<WeatherForecast>>>
{
}

internal sealed class GetWeatherForecastQueryHandler(IWeatherForecastService forecastService) : IRequestHandler<GetWeatherForecastQuery, Response<IEnumerable<WeatherForecast>>>
{
    public async Task<Response<IEnumerable<WeatherForecast>>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
    {
        return await forecastService.GetAsync();
    }
}
