﻿using LocationHunter.Core.Entities;
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
        private readonly IHttpClientSevice _httpClientSevice;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocationController(
            IIpService ipService,
            IHttpClientSevice httpClientSevice,
            IHttpContextAccessor httpContextAccerssor)
        {
            _ipService = ipService;
            _httpClientSevice = httpClientSevice;
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

            var testIp = IPAddress.Parse("212.35.179.101");

            var d = await _httpClientSevice.GetLocation(testIp);
            return Ok(d);
        }
    }
}
