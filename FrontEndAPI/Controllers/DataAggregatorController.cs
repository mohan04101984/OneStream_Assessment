using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class DataAggregatorController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public DataAggregatorController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET Endpoint
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var weatherTask = _httpClient.GetStringAsync("https://localhost:7234/api/weather");
        var stockTask = _httpClient.GetStringAsync("https://localhost:7008/api/stock");

        // Await all calls asynchronously
        await Task.WhenAll(weatherTask, stockTask);

        var weatherResult = JsonConvert.DeserializeObject<dynamic>(await weatherTask);
        var stockResult = JsonConvert.DeserializeObject<dynamic>(await stockTask);

        return Ok(new
        {
            Weather = weatherResult,
            Stock = stockResult
        });
    }

    // POST Endpoint
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DataRequestModel model)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7234/api/weather", model);
        var result = await response.Content.ReadAsStringAsync();

        return Ok(result);
    }
}

public class DataRequestModel
{
    public string Symbol { get; set; }
}