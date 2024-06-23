namespace Sign.BoundContext.Domain;

public class DataTimeProvider : IDateTimeProvider
{
    public DateOnly GetDateOnly()
    {
        var date = DateTime.Now.Date;

        return DateOnly.FromDateTime(date);
    }
}