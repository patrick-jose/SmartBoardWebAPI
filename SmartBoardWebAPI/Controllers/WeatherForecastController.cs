using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace SmartBoardWebAPI.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public User Get()
        {
            using (IDbConnection cnn = NpgsqlConnection(""))

            return new User {
                Id = 1,
                Name = "Teste",
                Password = "testepw"
            };
        }
    }

    public class User {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
    }
}