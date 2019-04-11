using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace stroisoft.Controllers
{
    [Route("api/[controller]")]
    public class EchoController : Controller
    {
        [HttpPost("[action]")]
        public async Task<string> Send()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                return await reader.ReadToEndAsync();
            }
        }
    }
}
