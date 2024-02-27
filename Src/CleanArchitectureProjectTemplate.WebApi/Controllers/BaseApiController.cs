using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureProjectTemplate.WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseApiController : ControllerBase
{
    private IMediator? mediator;
    protected IMediator? Mediator => mediator ??= HttpContext?.RequestServices.GetService<IMediator>();
}
