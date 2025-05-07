using FCG.API.Configuration.Log;

namespace FCG.API.Configuration.Middleware.GlobalExceptionHandling;

public class GlobalExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context, BaseLogger logger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {  
            logger.LogError($"An unhandled exception occurred: {ex.Message}");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
        }
    }
}

