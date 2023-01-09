using FirstWebApiApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApiApp.Controllers
{
    [ApiController]
    //[Route("[controller]/[Action]")]
    //[Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("forecasts/list")]
        public IEnumerable<WeatherForecast> abuzittin()
        {
            List<WeatherForecast> list = new List<WeatherForecast>();

            for (int i = 0; i < 5; i++)
            {
                WeatherForecast item = new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };

                list.Add(item);
            }

            return list;

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }

        [HttpPost("add-forecast")]
        public WeatherForecast ert(WeatherForecastAddModel model)
        {
            WeatherForecast weather = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = model.TempC,
                Summary = model.Summary
            };

            return weather;
        }
    }
}