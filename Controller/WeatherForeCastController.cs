using Microsoft.AspNetCore.Mvc;

namespace MinimalApi
{
    [ApiController]
    [Route("[action]")]
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
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "Messages")]
        public IEnumerable<Message> Messages()
        { 
            List<Message> messages = new List<Message>();
            messages.Add(new Message() { Id = 1, Sender = "FLIGHT OPERATIONS", Title = "Training Expiration 30 day Warning", Content = "This is a sample message for reminding the training expiry. Training Expiration 30 day Warning Message" });
            messages.Add(new Message() { Id = 1, Sender = "ADMIN", Title = "New Pilot CCS", Content = "Test Message from New Pilot CCS Application" });
            messages.Add(new Message() { Id = 1, Sender = "CURTIS HINKLE", Title = "A Simple Test Message", Content = "This is a simple Test Message from New Pilot CCS application used for demo purpose." });
            messages.Add(new Message() { Id = 1, Sender = "CURTIS HINKLE", Title = "Training Expiry", Content = "Training Expiration 10 day Warning Message" });
            return messages.AsEnumerable();
        }
    }
}
