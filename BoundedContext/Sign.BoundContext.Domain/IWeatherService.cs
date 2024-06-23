namespace Sign.BoundContext.Domain;

public interface IWeatherService
{
    decimal GetTemp();
    
    
    WeatherForecast GetForecast();
    
    WeatherForecast GetForecastExp();
    
    // Zwróc mi prognozę pogody na n dni w dni wolne od pracy.
    // w najbliższych możliwych dniach wolnych - true
    // w aktualnym (zalozenie jestesmy w trakcie dni wolnych) - false
    List<WeatherForecast> WeatherForecastOnHolidays(int n, bool future);
}