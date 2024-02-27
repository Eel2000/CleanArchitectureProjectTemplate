using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Serilog;
using VirtualManagerSystem.Domain.Commons;

namespace CleanArchitectureProjectTemplate.WebApi.Extensions;

public static class GlobalExceptionHandler
{

    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        _ = app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    Log.Logger.Fatal(contextFeature.Error, "An error occured while processing");

                    var error = new Response<object>()
                    {
                        Succeeded = false,
                        Message = contextFeature.Error.InnerException is null ?
                        contextFeature.Error.Message :
                        contextFeature.Error.InnerException.Message
                    };
                    var errorJson = JsonConvert.SerializeObject(error);
                    await context.Response.WriteAsync(errorJson);
                }
            });
        });
    }
}