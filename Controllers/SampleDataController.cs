using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.SPADemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore.SPADemo.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        private ItemContext itemContext;

        public SampleDataController(ItemContext itemContext)
        {
            this.itemContext = itemContext;
        }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<Item> WeatherForecasts()
        {
            // var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //     DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
            //     TemperatureC = rng.Next(-20, 55),
            //     Summary = Summaries[rng.Next(Summaries.Length)]
            // });
            return itemContext.Items.ToArray();
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
