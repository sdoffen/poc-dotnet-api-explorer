using Hellang.Middleware.ProblemDetails;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FullCircle.Extensions.ProblemDetails;

public static class CompositionExtensions
{
    public static IServiceCollection ConfigureVcaProblemDetails(this IServiceCollection services)
    {
        ProblemDetailsExtensions.AddProblemDetails(services);
        services.AddProblemDetailsConventions();

        services.ConfigureOptions<ProblemDetailsOptionsConfigurator>();

        return services;
    }

    public static IApplicationBuilder UseVcaProblemDetails(this IApplicationBuilder app)
    {
        app.UseProblemDetails();
        return app;
    }
}
