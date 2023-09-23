using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace azure_app_configuration.Controllers
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
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IFeatureManager featureManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _featureManager = featureManager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var featureEnabled = await _featureManager.IsEnabledAsync("showSummary");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = _configuration.GetValue<int>("test-key"),
                Summary = featureEnabled ? Summaries[Random.Shared.Next(Summaries.Length)] : null
            })
            .ToArray();
        }
    }
}