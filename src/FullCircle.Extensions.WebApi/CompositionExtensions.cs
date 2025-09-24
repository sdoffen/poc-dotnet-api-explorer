using FullCircle.Extensions.WebApi.Configuration;
using FullCircle.Extensions.WebApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullCircle.Extensions.WebApi;

public static class CompositionExtensions
{
    public static IServiceCollection ConfigureVcaOpenApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OpenApiOptions>(configuration.GetSection(OpenApiOptions.SectionName));
        services.ConfigureOptions<OpenApiOptionsConfigurator>();

        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new(1, 0);
        }).AddMvc()
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        services.AddSwaggerGen(options =>
        {
            options.SchemaFilter<SwaggerExcludeFilter>();
            options.DocumentFilter<SwaggerExcludeFilter>();
            options.OperationFilter<ProblemDetailsFilter>();
        });

        services.ConfigureOptions<ApiVersionsConfigurator>();
        services.ConfigureOptions<XmlDocsConfigurator>();
        services.ConfigureOptions<SwaggerUIOptionsConfigurator>();
        services.ConfigureOptions<RouteTemplateConfigurator>();

        return services;
    }

    public static IApplicationBuilder UseVcaSwaggerUI(this IApplicationBuilder app, bool useSwaggerUI = true)
    {
        if (useSwaggerUI)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}
