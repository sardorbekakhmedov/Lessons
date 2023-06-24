using Microsoft.AspNetCore.SignalR;

namespace Lesson77_ApiSignalR.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("newMessage", message);
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
}