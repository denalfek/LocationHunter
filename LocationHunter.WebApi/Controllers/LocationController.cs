using LocationHunter.Core.Entities;
using LocationHunter.Dal;
using LocationHunter.WebApi.Extensions;
using LocationHunter.WebApi.Services.Interfaces;
using MaxMind.GeoIP2;
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
        private readonly IIpService _ipService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocationController(
            IIpService ipService,
            IHttpContextAccessor httpContextAccerssor)
        {
            _ipService = ipService;
            _httpContextAccessor = httpContextAccerssor;
        }

        [HttpGet, Route("country")]
        public async Task<IActionResult> GetCountryByIp()
        {
            var ip = _httpContextAccessor.HttpContext.Request.GetIp();

            if(string.IsNullOrEmpty(ip.ToString())) { return BadRequest("Couldn't parse ip"); }

            var result = await _ipService.GetLocationsAsync(1);

            return Ok(result);
        }

        [HttpGet, Route("test")]
        public async Task<IActionResult> TestIpStack()
        {
            var ip = _httpContextAccessor.HttpContext.Request.GetIp();

            using var client = new WebClient
            {
                BaseAddress = "http://api.ipstack.com/"
            };
            const string accessKeyStr =
                "?access_key=928f5a5bb4d4963a5c90cc7d31e382e6";
            var request = ip.ToString() + accessKeyStr;
            return Ok(client.DownloadString(request));
        }
    }
}
