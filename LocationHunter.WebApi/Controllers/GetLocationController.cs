using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetLocationController : ControllerBase
    {
        [HttpGet]
        public IActionResult TryIp()
        {
            var ip = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            if(string.IsNullOrEmpty(ip)) { return Ok("Couldn't parse ip"); }

            return Ok(ip);
        }
    }
}
