using Contracts;
using ipo.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly LoggerManager _logger;
        private static readonly string[] Summaries = new[]
        {
            "Freeze", "Brace", "Chill", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorch"
        };


        public WeatherForecastController(LoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ServiceFilter(typeof(LoggerFilter))]
        public IEnumerable<WeatherForecast> Get()
        {
            //throw new Exception();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
