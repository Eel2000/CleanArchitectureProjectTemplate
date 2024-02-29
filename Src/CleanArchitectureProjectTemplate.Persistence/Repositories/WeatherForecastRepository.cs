﻿using CleanArchitectureProjectTemplate.Application.Interfaces.Repositories;
using CleanArchitectureProjectTemplate.Domain.Entities;
using CleanArchitectureProjectTemplate.Persistence.Contexts;
using CleanArchitectureProjectTemplate.Persistence.Repositories.Base;

namespace CleanArchitectureProjectTemplate.Persistence.Repositories;

internal sealed class WeatherForecastRepository(ApplicationDataContext context) : BaseRepository<WeatherForecast>(context), IWeatherForecastRepository
{
}
