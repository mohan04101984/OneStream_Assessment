using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(3000); // Simulate a delay of 3 seconds
            return Ok(new { Symbol = "AAPL", Price = "150.25" });
        }
    }
}

