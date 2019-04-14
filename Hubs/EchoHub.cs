using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;

namespace stroisoft
{
    public class EchoHub : Hub
    {
        private EchoContext _dbContext;
        
        public EchoHub(EchoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Login(string username)
        {
            var callerId = Context.ConnectionId;

            _dbContext.Users.Add(new User
            {
                ClientId = callerId,
                Username = username
            });
            _dbContext.SaveChanges();
            await Clients.Caller.SendAsync("loggedIn");
        }
        
        public async Task SendEcho(string message)
        {
            var callerId = Context.ConnectionId;
            var user = _dbContext.Users.Where(x => x.ClientId == callerId).FirstOrDefault();
            var username = user.Username;
            
            var result = string.Format("{0} ({1}) {2}", DateTime.Now.ToString(), username, message);
            
            _dbContext.Messages.Add(new Message { Text = result });
            _dbContext.SaveChanges();

            await Clients.All.SendAsync("echo", result);
        }
    }
}