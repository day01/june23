namespace Sign.BoundContext.Domain;

public class WeatherService(IWeatherRepository weatherRepository, IDateTimeProvider dateTimeProvider) : IWeatherService
{
    public decimal GetTemp()
    {
        return weatherRepository.GetTemp();
    }

    public WeatherForecast GetForecast()
    {
        return new WeatherForecast {Temp = 9999};
    }

    public WeatherForecast GetForecastExp()
    {
        throw new NotImplementedException();
    }

    public List<WeatherForecast> WeatherForecastOnHolidays(int n, bool future)
    {
        throw new NotImplementedException();
    }

    public List<WeatherForecast> WeatherForecastOnNDays(int n)
    {
        var a = dateTimeProvider.GetDateOnly();
        if (n == 5)
        {
            return new List<WeatherForecast>() {new(), new(), new()};
        }

        return new List<WeatherForecast>();
    }
}


// a -> b -> c -> d

//             infrastructure
//                   |
//                   \/
// application -> domain 