using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using FullCircle.Api.Dto;

namespace FullCircle.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets the weather forecast for the next 5 days for a given city.
    /// </summary>
    /// <param name="city"></param>
    /// <returns></returns>
    [HttpGet("{city}")]
    public IEnumerable<WeatherForecast> GetByCity(string city)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    /// <summary>
    /// Gets the weather forecast for the next 5 days for a given location.
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    [HttpPost()]
    public IEnumerable<WeatherForecast> GetByLocation([FromBody] Location location)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
