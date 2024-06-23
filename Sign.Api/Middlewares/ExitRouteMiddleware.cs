namespace Sign.Api.Middlewares;

// Przerabiamy dany middleware na logujący czas wykonania, route. 
// W tym celu dajemy 2 route'y, jeden z exp, drugi bez. bazując na tym co już mamy w Ctrl.
public class ExitRouteMiddleware
{
    public static Func<HttpContext, Func<Task>, Task> Handle()
    {
        return async (context, next) =>
        {
            await next();
            var logger = context.RequestServices.GetService<ILogger<ExitRouteMiddleware>>()!;
            logger.LogInformation("Exit route: {Route}", context.Request.Path);
        };
    }
}