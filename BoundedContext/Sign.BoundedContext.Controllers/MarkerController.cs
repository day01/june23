using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sign.BoundContext.Domain;
using Sign.BoundedContext.Contract;

namespace Sign.BoundedContext.Controllers;

[Microsoft.AspNetCore.Components.Route("[controller]")]
public class MarkerController(IMapper mapper, IWeatherService service)
{
    [HttpGet("forecast")]
    public WeatherForecastDto GetForecast()
    {
        var forecast = service.GetForecast();
        return mapper.Map<WeatherForecastDto>(forecast);
    }
}