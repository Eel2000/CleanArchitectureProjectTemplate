using CleanArchitectureProjectTemplate.Application.Interfaces.Services;
using CleanArchitectureProjectTemplate.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureProjectTemplate.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //TODO: register here all the services and and validators
        services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

        return services;
    }
}
