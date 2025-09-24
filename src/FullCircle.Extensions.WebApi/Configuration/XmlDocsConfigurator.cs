using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FullCircle.Extensions.WebApi.Configuration;

public class XmlDocsConfigurator : IConfigureOptions<SwaggerGenOptions>
{
    private static readonly string[] _suffixes = new[] { ".Dto", ".Dtos" };

    private readonly ApplicationPartManager _partManager;

    public XmlDocsConfigurator(ApplicationPartManager partManager)
    {
        _partManager = partManager;
    }

    public void Configure(SwaggerGenOptions options)
    {
        var assemblies = _partManager.ApplicationParts
            .OfType<AssemblyPart>()
            .Select(p => p.Assembly.GetName().Name)
            .Distinct();

        foreach (var assembly in assemblies)
        {
            var baseXmlFile = $"{assembly}.xml";
            var baseXmlPath = Path.Combine(AppContext.BaseDirectory, baseXmlFile);
            if (File.Exists(baseXmlPath))
                options.IncludeXmlComments(baseXmlPath);

            foreach (var suffix in _suffixes)
            {
                var xmlFile = $"{assembly}{suffix}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    options.IncludeXmlComments(xmlPath);
                }
            }
        }
    }
}
