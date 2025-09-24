using FullCircle.Extensions.DataAnnotations;

namespace FullCircle.Api.Dto;

public class Location
{
    /// <summary>
    /// Latitude in decimal degrees.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Longitude in decimal degrees.
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// This should not show up in the Swagger UI.
    /// </summary>
    [SwaggerExclude]
    public string? Name { get; set; }
}
