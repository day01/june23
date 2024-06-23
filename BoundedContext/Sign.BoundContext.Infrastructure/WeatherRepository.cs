using Sign.BoundContext.Domain;

namespace Sign.BoundContext.Infrastructure;

public class WeatherRepository : IWeatherRepository
{
    public decimal GetTemp()
    {
        throw new NotImplementedException();
    }

    public WeatherForecast GetForecast()
    {
        // dbContext.WeatherForecasts.FirstOrDefault();
        throw new NotImplementedException();
    }
}