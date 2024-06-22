using AspEbPattern.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspEbPattern.Controllers;

[Route("[controller]")]
public class WeatherController(ILogger<WeatherController> logger, ITaskQueue taskQueue) : ControllerBase
{
    private readonly ILogger _logger = logger;
    private readonly ITaskQueue _taskQueue = taskQueue;

    [HttpGet(Name = "WeatherSomeInfo")]
    public string GetSomeInfo()
    {
        _taskQueue.Queue(token =>
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _logger.LogInformation("Weather request positive at {EndOfRequest}", DateTime.Now);
        });
        
        _logger.LogInformation("Weather requested at {EndOfRequest}", DateTime.Now);
        return "Sunny day!";
    }
}