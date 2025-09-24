using System.Reflection;
using Microsoft.Extensions.Options;

namespace FullCircle.Extensions.WebApi.Configuration;

public class OpenApiOptionsConfigurator : IPostConfigureOptions<OpenApiOptions>
{
    public void PostConfigure(string? name, OpenApiOptions options)
    {
        options.Title ??= Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown Calling Assembly";
        options.GroupNamePrefix ??= options.Title;
    }
}
