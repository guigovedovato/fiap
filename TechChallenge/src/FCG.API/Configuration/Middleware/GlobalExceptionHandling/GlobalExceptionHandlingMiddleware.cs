using FCG.Domain.Common.Exceptions;
using FCG.Infrastructure.Log;

namespace FCG.API.Configuration.Middleware.GlobalExceptionHandling;

public class GlobalExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context, BaseLogger logger)
    {
        var errorId = Guid.NewGuid();
        try
        {
            await _next(context);
        }
        catch (EntityDoesNotExistException ex)
        {
            logger.LogError($"Error: {errorId}. {ex.Message}");
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync($"An unexpected fault happened. Try again later. Error: {errorId}.");
        }
        catch (BadHttpRequestException ex)
        {
            logger.LogError($"Error: {errorId}. {ex.Message}");
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync($"An unexpected fault happened. Try again later. Error: {errorId}.");
        }
        catch (Exception ex)
        {
            logger.LogError($"Error: {errorId}. An unhandled exception occurred: {ex.Message}");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync($"An unexpected fault happened. Try again later. Error: {errorId}.");
        }
    }
}

