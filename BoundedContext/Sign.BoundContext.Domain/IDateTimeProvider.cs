namespace Sign.BoundContext.Domain;

public interface IDateTimeProvider
{
    DateOnly GetDateOnly();
}