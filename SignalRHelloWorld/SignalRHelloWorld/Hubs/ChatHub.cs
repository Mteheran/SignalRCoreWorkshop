using Microsoft.AspNetCore.SignalR;
using SignalRHelloWorld.Hubs.Interfaces;
using SignalRHelloWorld.Hubs.Models;
using System;
using System.Threading.Tasks;

namespace SignalRHelloWorld.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task SendMessage(ChatMessage chatMessage)
        {
            await Clients.All.RecieveMessage(chatMessage);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId).RecieveMessage(new ChatMessage() { User= "Host", Message= "Welcome" });
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.RecieveMessage(new ChatMessage() { User = "Host", Message = Context.ConnectionId + " left" });
            await base.OnDisconnectedAsync(exception);
        }
    }
}
