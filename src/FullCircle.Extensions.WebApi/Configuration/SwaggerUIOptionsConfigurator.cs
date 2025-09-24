using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace FullCircle.Extensions.WebApi.Configuration;

public class SwaggerUIOptionsConfigurator : IConfigureOptions<SwaggerUIOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly OpenApiOptions _options;

    public SwaggerUIOptionsConfigurator(IApiVersionDescriptionProvider provider, IOptions<OpenApiOptions> options)
    {
        _provider = provider;
        _options = options.Value;
    }

    public void Configure(SwaggerUIOptions options)
    {
        options.RoutePrefix = _options.RoutePrefix;

        foreach (var description in _provider.ApiVersionDescriptions)
        {
            var path = string.Format(_options.RouteTemplate, description.GroupName);
            var name = $"{_options.GroupNamePrefix} {description.GroupName.ToLowerInvariant()}";
            options.SwaggerEndpoint(path, name);
        }
    }
}
