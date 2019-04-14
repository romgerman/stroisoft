using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace stroisoft
{
    public class EchoHub : Hub
    {
        private EchoContext _dbContext;
        
        public EchoHub(EchoContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task SendEcho(string message)
        {
            var callerId = Context.ConnectionId;
            var result = string.Format("{0} ({1}) {2}", DateTime.Now.ToString(), callerId, message);
            
            _dbContext.Messages.Add(new Message { Text = result });
            _dbContext.SaveChanges();

            await Clients.All.SendAsync("echo", result);
        }
    }
}