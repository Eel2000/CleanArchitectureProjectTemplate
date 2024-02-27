using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureProjectTemplate.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //TODO: register here all the services and and validators

        return services;
    }
}
