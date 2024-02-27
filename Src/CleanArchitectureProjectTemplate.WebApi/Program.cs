using Asp.Versioning;
using CleanArchitectureProjectTemplate.Application.Extensions;
using CleanArchitectureProjectTemplate.WebApi.Extensions;
using CleanArchitectureProjectTemplate.WebApi.OpenApi;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        @$"C:/Logs/Log-{DateTime.Now.ToString("d")}.txt",
        fileSizeLimitBytes: 1_000_000,
        rollOnFileSizeLimit: true,
        shared: true,
        flushToDiskInterval: TimeSpan.FromSeconds(1))
    .CreateBootstrapLogger();

try
{
    Log.Information("Application started");

    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    }).AddApiExplorer(options => { options.GroupNameFormat = "'v'VVV"; });

    builder.Services.AddMediatR(options =>
    {
        options.RegisterServicesFromAssemblies(AssemblyExtension.GetApplicationLayerAssembly());
    });

    builder.Services.AddApplication();

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseCors(x => x
       .AllowAnyMethod()
       .AllowAnyHeader()
       .SetIsOriginAllowed(origin => true)
       .AllowCredentials());

    app.MapControllers();

    app.UseSwaggerDocumentation();

    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
