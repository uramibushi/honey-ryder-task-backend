#pragma warning disable CS1591 // xxx
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1600 // Elements should be documented
using Microsoft.AspNetCore.Mvc;

namespace HoneyRyderTask.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
        })
        .ToArray();
    }
}
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore CS1591 // xxx
