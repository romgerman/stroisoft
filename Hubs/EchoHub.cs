using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace stroisoft
{
    public class EchoHub : Hub
    {
        public async Task SendEcho(string message)
        {
            await Clients.All.SendAsync("echo", message);
        }
    }
}