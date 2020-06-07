using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication5.Model;
using WebApplication5.ViewModel;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]
        public EmployeeViewModel Get(Employee employee)
        {
/*            public EmployeeViewModel Build(Employee employee)
            {*/
                var viewModel = new EmployeeViewModel();
                viewModel.DisplayName = employee.FirstName + " " + employee.LastName;
                if (employee.Location == "Store")
                {
                    viewModel.Responsibilities.Add("Stock Shelves");
                    viewModel.Responsibilities.Add("Customer Service");
                }
                else
                {
                    viewModel.Responsibilities.Add("Load Warehouse Trucks");
                }
                return viewModel;
/*            }*/








            /*            var rng = new Random();
                        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = rng.Next(-20, 55),
                            Summary = Summaries[rng.Next(Summaries.Length)]
                        })
                        .ToArray();*/
        }
    }
}
