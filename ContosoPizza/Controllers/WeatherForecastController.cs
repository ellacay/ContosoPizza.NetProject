using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
private IEnumerable<WeatherForecast> GetDaysOverTemperature(IEnumerable<WeatherForecast> records, int temp)
        {
            return records.Where(r => r.TemperatureC > temp).ToArray();
        }
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
  public IEnumerable<WeatherForecast> Get()
        {
            IEnumerable<WeatherForecast> records = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
     
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            
            // Filter the records to give us forecasts over 25 degrees
            records = GetDaysOverTemperature(records, 25);

            return records;
        }
}
