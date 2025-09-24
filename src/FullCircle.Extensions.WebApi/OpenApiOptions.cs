using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;

namespace FullCircle.Extensions.WebApi;

[ExcludeFromCodeCoverage]
public class OpenApiOptions
{
    public static readonly string SectionName = "OpenApi";

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactName { get; set; }

    public string? ContactUrl { get; set; }

    public string RouteTemplate { get; set; } = "/api/{0}/openapi.json";

    public string RoutePrefix { get; set; } = "api/swagger";

    public string GroupNamePrefix { get; set; } = null!;
}


public static class OpenApiOptionsExtensions
{
    public static OpenApiContact? ContactInfo(this OpenApiOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ContactEmail) &&
            string.IsNullOrWhiteSpace(options.ContactName) &&
            string.IsNullOrWhiteSpace(options.ContactUrl))
        {
            return null;
        }

        var contact = new OpenApiContact();

        if (options.ContactEmail is not null)
            contact.Email = options.ContactEmail;

        if (options.ContactName is not null)
            contact.Name = options.ContactName;

        if (options.ContactUrl is not null && Uri.TryCreate(options.ContactUrl, UriKind.Absolute, out var url))
            contact.Url = url;

        return contact;
    }
}
