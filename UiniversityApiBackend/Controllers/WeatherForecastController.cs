using Microsoft.AspNetCore.Mvc;

namespace UiniversityApiBackend.Controllers
{
    [ApiController]
    [Route("[controller]")] /*COn route esta accediendo al 
                             servidor nuestro de localhost localhost:7190/WeatherForecast*/
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

        //MEthod HTTTP de tipo get
        [HttpGet(Name = "GetWeatherForecast")]
        /*Cuando llamamos al GetWeatherForecast 
         lo que hacemos es que se ejecute esta funcion que 
        devuelve un enumerable*/
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}