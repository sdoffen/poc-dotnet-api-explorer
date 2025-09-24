using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace FullCircle.Extensions.ProblemDetails;

public class ProblemDetailsOptionsConfigurator : IConfigureOptions<Hellang.Middleware.ProblemDetails.ProblemDetailsOptions>
{
    private readonly IWebHostEnvironment _env;

    public ProblemDetailsOptionsConfigurator(IWebHostEnvironment env)
    {
        _env = env;
    }

    public void Configure(Hellang.Middleware.ProblemDetails.ProblemDetailsOptions options)
    {
        options.IncludeExceptionDetails = (ctx, ex) => _env.IsDevelopment();

        options.MapToStatusCode<NotImplementedException>(StatusCodes.Status501NotImplemented);

        options.MapToStatusCode<HttpRequestException>(StatusCodes.Status503ServiceUnavailable);

        options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
    }
}
