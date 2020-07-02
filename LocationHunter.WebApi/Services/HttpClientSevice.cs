using LocationHunter.WebApi.Extensions;
using LocationHunter.WebApi.IpStackModels;
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
        private readonly string _clientName;

        public HttpClientSevice(
            IHttpClientFactory httpClientFactory,
            HttpClientExtensions httpClientExtensions)
        {
            _httpClientFactory = httpClientFactory;
            _accessKey = httpClientExtensions.AccessKey;
            _clientName = httpClientExtensions.ClientName;
        }

        public async Task<IpStackResponseModel> GetLocation(IPAddress iPAddress)
        {
            using var client = _httpClientFactory.CreateClient(_clientName);
            var response = await client.SendAsync(
                    new HttpRequestMessage(HttpMethod.Get, string.Concat(iPAddress, _accessKey)));

            return JsonConvert
                .DeserializeObject<IpStackResponseModel>(await
                    response.Content.ReadAsStringAsync());
        }
    }
}
