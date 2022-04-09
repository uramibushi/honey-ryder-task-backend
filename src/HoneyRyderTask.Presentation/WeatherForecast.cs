#pragma warning disable CS1591 // xxx
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1600 // Elements should be documented
namespace HoneyRyderTask.Presentation;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}
#pragma warning restore SA1600 // Elements should be documented
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore CS1591 // xxx