using LocationHunter.Core.Configurations;
using LocationHunter.Core.Entities;
using LocationHunter.Core.Services.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocationHunter.Core.Services
{
    public class HttpClientSevice : IHttpClientSevice
    {
        private static HttpClient _httpClient;
        private readonly string _accessKey;

        public HttpClientSevice(
            HttpClientConfig httpClientConfig)
        {
            if (_httpClient == null) { }
                _httpClient = new HttpClient
                {
                    BaseAddress = httpClientConfig.Uri
                };
        }

        public async Task<Location> GetLocation(IPAddress iPAddress)
        {            
            var response = await _httpClient.SendAsync(
                    new HttpRequestMessage(HttpMethod.Get, string.Concat(iPAddress, _accessKey)));

            var responseModel = JsonConvert
                .DeserializeObject<IpStackResponseModel>(await
                    response.Content.ReadAsStringAsync());
        }
    }
}
