namespace Sign.BoundContext.Domain;

public interface IWeatherService
{
    decimal GetTemp();
    
    
    WeatherForecast GetForecast();
}