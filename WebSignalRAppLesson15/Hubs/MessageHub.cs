using Microsoft.AspNetCore.SignalR;
using WebSignalRAppLesson15.Helpers;

namespace WebSignalRAppLesson15.Hubs;
public class MessageHub : Hub
{
    public async override Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveConnectInfo","User Connected !");
    }

    public async override Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.Others.SendAsync("ReceiveDisconnectInfo", "User Disconnected !");
    }

    // this method will invoked when user will join to the room :
    public async Task JoinRoom(string room, string user)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, room);
        await Clients.OthersInGroup(room).SendAsync("ReceiveJoinInfo", user);
    }

    // this method will invoked when user will exit the room :
    public async Task ExitRoom(string room,string user)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
        await Clients.OthersInGroup(room).SendAsync("ReceiveExitInfo", user);
    }

    // this method will send car's current price which user selected : 
    public async Task SendMessageRoom(string room, string user)
    {
        await Clients.Group(room).SendAsync("ReceiveInfoRoom", user, FileHelper.GetCurrentPrice(room));
    }

    // 
    public async Task SendInitialPrice(string room)
    {
        await Clients.Group(room).SendAsync("ReceiveInitialPrice",FileHelper.GetBeginPrice(room));
    }

    // this message will invoked when one of the user will win : 
    public async Task SendWinnerMessageRoom(string room, string message)
    {
        await Clients.Group(room).SendAsync("ReceiveWinInfoRoom", message, FileHelper.GetCurrentPrice(room));
    }
}
