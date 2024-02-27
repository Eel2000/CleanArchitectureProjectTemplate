using CleanArchitectureProjectTemplate.Application.Interfaces.Repositories;
using CleanArchitectureProjectTemplate.Application.Interfaces.Repositories.Base;
using CleanArchitectureProjectTemplate.Persistence.Contexts;
using CleanArchitectureProjectTemplate.Persistence.Repositories;
using CleanArchitectureProjectTemplate.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureProjectTemplate.Persistence.Extensions;

public static class PersistenceExtension
{
#if DEBUG
    private const string CON_STRING = "Development";
#elif RELEASE
    private const string CON_STRING = "Production";
#endif

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(CON_STRING), b => b.MigrationsAssembly(typeof(ApplicationDataContext).Assembly.FullName));
            options.EnableDetailedErrors();
            options.LogTo(Console.WriteLine);
        });

        #region Repositories

        services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();

        #endregion

        return services;
    }
}
