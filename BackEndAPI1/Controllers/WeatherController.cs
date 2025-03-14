using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(2000); // Simulate a delay of 2 seconds
            return Ok(new { Temperature = "22°C", Condition = "Sunny" });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WeatherRequest request)
        {
            await Task.Delay(2000); // Simulate processing time

            return Ok(new
            {
                Message = $"Weather data updated for location: {request.Location}",
                Temperature = request.Temperature
            });
        }
    }

    public class WeatherRequest
    {
        public string Location { get; set; }
        public string Temperature { get; set; }
    }
}
