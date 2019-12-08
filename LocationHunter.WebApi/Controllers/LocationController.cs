using LocationHunter.Core.Entities;
using LocationHunter.Dal;
using LocationHunter.WebApi.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var ip = _httpContextAccessor.HttpContext.Request.GetIp();

            if(string.IsNullOrEmpty(ip.ToString())) { return BadRequest("Couldn't parse ip"); }

            var result = await GetLocationName(ip);
            
            return Ok(result);
        }

        private async Task TestDb(IPAddress ip)
        {
            _db.Locations.Add(new Location() { Ip = ip, Name = "localhost" });
            await _db.SaveChangesAsync();
        }

        private async Task<string> GetLocationName(IPAddress ip)
        {
            try
            {
                await TestDb(ip);

                var locationName = _db.Locations.FirstOrDefault(l => l.Ip == ip).Name;
                
                if (!string.IsNullOrEmpty(locationName))
                {
                    return locationName;
                }
            }
            catch (Exception ex)
            {
                var test = ex;
            }

            return $"Couldn't get location by your ip: {ip.ToString()}";
        }
    }
}
