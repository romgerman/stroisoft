using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace stroisoft
{
    public class EchoHub : Hub
    {
        public async Task SendEcho(string message)
        {
            var callerId = Context.ConnectionId;
            
            await Clients.All.SendAsync("echo", string.Format("{0} ({1}) {2}", DateTime.Now.ToString(), callerId, message));
        }
    }
}