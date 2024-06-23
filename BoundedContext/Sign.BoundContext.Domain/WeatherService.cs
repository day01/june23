namespace Sign.BoundContext.Domain;

public class WeatherService(IWeatherRepository weatherRepository) : IWeatherService
{
    public decimal GetTemp()
    {
        return weatherRepository.GetTemp();
    }

    public WeatherForecast GetForecast()
    {
        throw new NotImplementedException();
    }
}


// a -> b -> c -> d

//             infrastructure
//                   |
//                   \/
// application -> domain 