namespace Sign.BoundContext.Domain;

public class WeatherService(IWeatherRepository weatherRepository) : IWeatherService
{
    public decimal GetTemp()
    {
        return weatherRepository.GetTemp();
    }

    public WeatherForecast GetForecast()
    {
        return new WeatherForecast {Temp = 9999};
    }
    
    
}


// a -> b -> c -> d

//             infrastructure
//                   |
//                   \/
// application -> domain 