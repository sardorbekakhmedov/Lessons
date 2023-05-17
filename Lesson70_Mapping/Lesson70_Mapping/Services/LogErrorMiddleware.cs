namespace Lesson70_Mapping.Services;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class LogErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogErrorMiddleware> _iLogger;

    public LogErrorMiddleware(RequestDelegate next, ILogger<LogErrorMiddleware> iLogger)
    {
        _next = next;
        _iLogger = iLogger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception e)
        {
            _iLogger.LogError(e, "Internal ERROR");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
           await httpContext.Response.WriteAsJsonAsync(new { Error = "Internal ERROR" });
        }
       
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogErrorMiddleware>();
    }
}