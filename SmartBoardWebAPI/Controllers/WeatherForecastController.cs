using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

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
        public void Get()
        {
            var user = new User {
                Id = 1,
                Name = "Teste",
                Password = "testepw"
            };

            using (IDbConnection cnn = new NpgsqlConnection("Host=SmartBoardDB;Username=postgres;Password=postgrespw;Database=smartboarddb"))
            {
                string sqlInsert = "INSERT INTO user VALUES(@Id, @Name, @Password)";

                cnn.Open();
                cnn.Execute(sqlInsert, user);
            }
        }
    }

    public class User {
        public long Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
    }
}