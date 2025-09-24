using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace FullCircle.Extensions.WebApi.Configuration;

public class RouteTemplateConfigurator : IConfigureOptions<SwaggerOptions>
{
    private readonly OpenApiOptions _options;

    public RouteTemplateConfigurator(IOptions<OpenApiOptions> options)
    {
        _options = options.Value;
    }

    public void Configure(SwaggerOptions options)
    {
        options.RouteTemplate = string.Format(_options.RouteTemplate, "{documentName}");
    }
}
