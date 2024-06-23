using AutoMapper;
using Sign.BoundContext.Domain;
using Sign.BoundedContext.Contract;

namespace Sign.BoundedContext.Controllers;

public class WeatherProfile : Profile
{
    public WeatherProfile()
    {
        CreateMap<WeatherForecast, WeatherForecastDto>()
            .ForMember(x=> x.Temp, opt=> opt.MapFrom(y=> y.Temp * 10))
            .ReverseMap();
    }
}
