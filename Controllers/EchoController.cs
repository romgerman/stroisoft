using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace stroisoft.Controllers
{
    [Route("api/[controller]")]
    public class EchoController : Controller
    {
        private IHubContext<EchoHub> _hubContext;
        
        public EchoController(IHubContext<EchoHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        [HttpPost("[action]")]
        public async void Send()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                var text = await reader.ReadToEndAsync();
                await _hubContext.Clients.All.SendAsync("echo", text);
            }
        }
    }
}
