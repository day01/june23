namespace Sign.BoundContext.Domain;

public interface IWeatherRepository
{
    decimal GetTemp();
    
    WeatherForecast GetForecast();
}