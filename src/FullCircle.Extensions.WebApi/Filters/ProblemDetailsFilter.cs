using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FullCircle.Extensions.WebApi.Filters;

public class ProblemDetailsFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (!operation.Responses.ContainsKey("500")) return;

        operation.Responses["500"] = new OpenApiResponse
        {
            Description = "Internal Server Error",
            Content = new Dictionary<string, OpenApiMediaType>
            {
                ["application/problem+json"] = new OpenApiMediaType
                {
                    Schema = context.SchemaGenerator.GenerateSchema(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails), context.SchemaRepository)
                }
            }
        };
    }
}
