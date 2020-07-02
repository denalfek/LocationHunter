using System.Net;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Services.Interfaces
{
    public interface IHttpClientSevice
    {
        Task<ResponseModel> GetLocation(IPAddress iPAddress);
    }
}
