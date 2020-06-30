using LocationHunter.Core.Entities;
using LocationHunter.Dal;
using LocationHunter.WebApi.Extensions;
using LocationHunter.WebApi.Services.Interfaces;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly IIpService _ipService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;

        private const string ClientName = "ipStack";

        public LocationController(
            IIpService ipService,
            IHttpContextAccessor httpContextAccerssor,
            IHttpClientFactory httpClientFactory)
        {
            _ipService = ipService;
            _httpContextAccessor = httpContextAccerssor;
            _httpClientFactory = httpClientFactory;
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

            const string accessKeyStr =
                "?access_key=928f5a5bb4d4963a5c90cc7d31e382e6";

            using var client = _httpClientFactory.CreateClient(ClientName);
            var request = ip.ToString() + accessKeyStr;
            var requestMsg = new HttpRequestMessage(HttpMethod.Get, request);
            var response = await client.SendAsync(requestMsg);
            var d = await response.Content.ReadAsStringAsync();

            try
            {

                var resp = JsonConvert.DeserializeObject<ResponseModel>(d);
            }
            catch (Exception ex)
            {
                var e = ex.Message;
            }
            return Ok();
        }
    }
}
