using Microsoft.AspNetCore.Mvc;

namespace Lesson66_Logger.Controllers;

[ApiController]
[Route("[controller]")]
public class LogDemoController : ControllerBase
{
    private readonly ILogger<LogDemoController> _logger;

    public LogDemoController(ILogger<LogDemoController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string Ping()
    {
        _logger.LogInformation("Inside of Ping");
        return "Pong";
    }
}