using Asp.Versioning;
using CleanArchitectureProjectTemplate.Application.Features.WeatherForecasts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureProjectTemplate.WebApi.Controllers.v1;

[ApiVersion(1.0)]
public class WeatherForecastController : BaseApiController
{
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        ArgumentNullException.ThrowIfNull(Mediator);

        return Ok(await Mediator.Send(new GetWeatherForecastQuery()));
    }
}
