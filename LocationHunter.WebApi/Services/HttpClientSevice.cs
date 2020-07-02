using LocationHunter.WebApi.Extensions;
using LocationHunter.WebApi.Services.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Services
{
    public class HttpClientSevice : IHttpClientSevice
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _accessKey;
        private const string _clientName = "ipStack";

        public HttpClientSevice(
            IHttpClientFactory httpClientFactory,
            HttpClientExtensions httpClientExtensions)
        {
            _httpClientFactory = httpClientFactory;
            _accessKey = httpClientExtensions.AccessKey;
        }

        public async Task<ResponseModel> GetLocation(IPAddress iPAddress)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, string.Concat(iPAddress, _accessKey));
            using var client = _httpClientFactory.CreateClient(_clientName);
            var response = await client.SendAsync(request);

            return JsonConvert.DeserializeObject<ResponseModel>(await response.Content.ReadAsStringAsync());
        }
    }
}
