using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Lesson72_JWT.Services;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class LoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggerMiddleware> _iLogger;

    public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> iLogger)
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
            await httpContext.Response.WriteAsJsonAsync( new { Error = "UnHandle exception! "});
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class LoggerMiddlewareExtensions
{
    public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggerMiddleware>();
    }
}