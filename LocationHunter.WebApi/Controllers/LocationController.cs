using LocationHunter.WebApi.Extensions;
using LocationHunter.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _ipService;
        private readonly IHttpClientSevice _httpClientSevice;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocationController(
            ILocationService ipService,
            IHttpClientSevice httpClientSevice,
            IHttpContextAccessor httpContextAccerssor)
        {
            _ipService = ipService;
            _httpClientSevice = httpClientSevice;
            _httpContextAccessor = httpContextAccerssor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ip = _httpContextAccessor.HttpContext.Request.GetIp();

            if(string.IsNullOrEmpty(ip.ToString()))
            {
                return BadRequest("Couldn't parse ip");
            }

            var testIp = IPAddress.Parse("212.35.179.101");

            var response = await _httpClientSevice.GetLocation(testIp);

            // await _ipService.SaveLocationAsync(response);

            return Ok(response);
        }
    }
}
