using Microsoft.Extensions.Options;

namespace FullCircle.Api.Configuration;

public class RouteOptionsConfigurator : IPostConfigureOptions<RouteOptions>
{
    public void PostConfigure(string? name, RouteOptions options)
    {
        options.LowercaseUrls = true;
    }
}
