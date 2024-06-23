using Moq;
using Sign.BoundContext.Domain;

namespace TestDrivenDesign;

public class WeatherServiceTests
{
    [Fact]
    public void GetTempVerify_WeGetExpectedValue_ActualValueEqualsExpectedValue()
    {
        // arrange
        const decimal expectedTemp = 1;
        var dateTimeProvider = new Mock<IDateTimeProvider>();
        var weatherRepository = new Mock<IWeatherRepository>();
        weatherRepository.Setup(x => x.GetTemp()).Returns(expectedTemp);

        var srv = new WeatherService(weatherRepository.Object, dateTimeProvider.Object);

        // act
        var actualResult = srv.GetTemp();

        // assert
        Assert.Equal(expectedTemp, actualResult);
    }
    
    [Fact]
    public void WeatherForecastOnNDays_WeTryToGetForecastFor0Days_ReturnsEmptyList()
    {
        // arrange
        var dateTimeProvider = new Mock<IDateTimeProvider>();
        var weatherRepository = new Mock<IWeatherRepository>();
        var srv = new WeatherService(weatherRepository.Object, dateTimeProvider.Object);

        // act
        var actualResult = srv.WeatherForecastOnNDays(0);

        // assert
        Assert.Empty(actualResult);
    }
    
    [Fact]
    public void WeatherForecastOnNDays_WeTryToGetForecastFor5Days_ReturnsNDaysFromNowWithoutWeekend()
    {
        // arrange
        const int expectedCount = 3;
        var dateTimeProvider = new Mock<IDateTimeProvider>();
        var weatherRepository = new Mock<IWeatherRepository>();

        dateTimeProvider.Setup(x => x.GetDateOnly()).Returns(new DateOnly(2000, 1, 1));
        var srv = new WeatherService(weatherRepository.Object, dateTimeProvider.Object);

        // act
        var actualResult = srv.WeatherForecastOnNDays(5);

        // assert
        Assert.Equal(expectedCount, actualResult.Count);
    }
    
    [Fact]
    public void WeatherForecastOnNDays_WeTryToGetForecastFor5Days_ReturnsNDaysFromNowWithoutWeekend_2()
    {
        // arrange
        const int expectedCount = 1;
        var dateTimeProvider = new Mock<IDateTimeProvider>();
        var weatherRepository = new Mock<IWeatherRepository>();

        dateTimeProvider.Setup(x => x.GetDateOnly()).Returns(new DateOnly(2001, 1, 1));
        var srv = new WeatherService(weatherRepository.Object, dateTimeProvider.Object);

        // act
        var actualResult = srv.WeatherForecastOnNDays(5);

        // assert
        Assert.Equal(expectedCount, actualResult.Count);
    }
}

/*
request:
POST /users HTTP/1.1
Host: sth.de
Content-Type: application/json
Authorization: Bearer {token}
{
     "name": "John Doe",
     "email": "john.doe@sth.de"
}
   
response:
HTTP/1.1 201 Created
Content-Type: application/json
{
     "id": 123,
     "name": "John Doe",
     "email": "john.doe@sth.de"
}

*/