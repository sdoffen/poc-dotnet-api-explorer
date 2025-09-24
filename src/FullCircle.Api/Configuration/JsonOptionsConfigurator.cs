using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FullCircle.Api.Configuration;

public class JsonOptionsConfigurator : IPostConfigureOptions<JsonOptions>
{
    public void PostConfigure(string? name, JsonOptions options)
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
    }
}
