using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace FullCircle.Api.Configuration;

public class MvcOptionsConfigurator : IPostConfigureOptions<MvcOptions>
{
    public void PostConfigure(string? name, MvcOptions options)
    {
        options.OutputFormatters.RemoveType<StringOutputFormatter>();
        options.OutputFormatters.OfType<SystemTextJsonOutputFormatter>()
            .FirstOrDefault()?.SupportedMediaTypes.Remove("text/json");

        options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
        options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
        options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));

        options.ReturnHttpNotAcceptable = true;
    }
}
