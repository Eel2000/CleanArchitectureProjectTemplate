using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArchitectureProjectTemplate.WebApi.OpenApi;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, new OpenApiInfo
            {
                Title = "PROJECT-TITLE",
                Description = "PROJECT-DESCRIPTION",
                Version = description.ApiVersion.ToString(),
                Contact = new OpenApiContact
                {
                    Email = "PROJECT-CONTACT",//replace this by appropriate email
                    Name = "AUTHOR",//replace this by appropriate Company name
                }
            });
        }
    }
}