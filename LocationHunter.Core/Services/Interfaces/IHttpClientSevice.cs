using LocationHunter.Core.Entities;
using System.Net;
using System.Threading.Tasks;

namespace LocationHunter.Core.Services.Interfaces
{
    public interface IHttpClientSevice
    {
        Task<Location> GetLocation(IPAddress iPAddress);
    }
}
