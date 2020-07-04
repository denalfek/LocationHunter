using LocationHunter.WebApi.IpStackModels;
using System.Net;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Services.Interfaces
{
    public interface IHttpClientSevice
    {
        Task<IpStackResponseModel> GetLocation(IPAddress iPAddress);
    }
}
