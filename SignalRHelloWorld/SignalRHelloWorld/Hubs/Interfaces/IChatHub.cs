using SignalRHelloWorld.Hubs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRHelloWorld.Hubs.Interfaces
{
    public interface IChatHub
    {
        Task SendMessage(ChatMessage chatMessage);
        Task RecieveMessage(ChatMessage chatMessage);
    }
}
