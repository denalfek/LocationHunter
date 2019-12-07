using LocationHunter.Core.Entities;
using LocationHunter.Dal;
using LocationHunter.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocationController(
            LocationHunterDbContex db,
            IHttpContextAccessor httpContextAccerssor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccerssor;
        }

        [HttpGet]
        public async Task<IActionResult> TryIp()
        {
            var testIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var ip = _httpContextAccessor.HttpContext.Request.GetIp().ToString();

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
