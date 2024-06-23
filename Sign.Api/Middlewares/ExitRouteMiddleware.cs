namespace Sign.Api.Middlewares;

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