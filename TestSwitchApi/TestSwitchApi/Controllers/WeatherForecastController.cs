using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestSwitchApi.Controllers
{
    // THIS CONTROLLER IS STOCK CODE SO DO NOT HESITATE TO DELETE WHEN FIRST CONTROLLER IS SET UP.
    // CAN BE USED AS A TEMPLATE UNTIL THEN.
    // Also delete the WeatherForecast.cs model when necessary.
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            if (1 == 1)
            {
                var str = "f";
                Console.WriteLine(str);
            }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select
                (
                    index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)],
                    }
                )
                .ToArray();
        }
    }
}