using LocationHunter.Core.Entities;
using LocationHunter.Dal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly LocationHunterDbContex _db;

        public LocationController(LocationHunterDbContex db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> TryIp()
        {
            var ip = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            if(string.IsNullOrEmpty(ip)) { return BadRequest("Couldn't parse ip"); }

            //await TestDb(ip);
            
            return Ok(ip);
        }

        private async Task TestDb(string ip)
        {
            _db.Users.Add(new User { Ip = ip });
            await _db.SaveChangesAsync();

            var user = _db.Users.FirstOrDefault(u => u.Ip == ip);

            if (user != null)
            {
                var id = user.Id;
            }
        }
    }
}
