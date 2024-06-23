using Sign.BoundContext.Domain;

namespace Sign.BoundContext.Infrastructure;

public class ExternalWeatherRepository : IWeatherRepository
{
    public decimal GetTemp()
    {
        throw new NotImplementedException();
    }

    public WeatherForecast GetForecast()
    {
        throw new NotImplementedException();
    }
}