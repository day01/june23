
using Microsoft.AspNetCore.Mvc;

namespace Sign.Api.Controllers;

public class HomeController(ILogger<HomeController> logger) : ControllerBase
{
    private readonly ILogger _logger = logger;
}