using Lesson77_ApiSignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Lesson77_ApiSignalR.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IHubContext<ChatHub> _chatHub;

    public ValuesController(IHubContext<ChatHub> chatHub)
    {
        _chatHub = chatHub;
    }

    [HttpGet]
    public List<string> GetValues() => Values.Messages;


    [HttpPost]
    public async Task AddValue(string value)
    {
        Values.Messages.Add(value);
        await _chatHub.Clients.All.SendAsync("newMessage", value);
    }

}

public static class Values
{
    public static List<string> Messages = new()
    {
        "Ali",
        "Vali",
        "Gani",
        "Soli"
    };
}
