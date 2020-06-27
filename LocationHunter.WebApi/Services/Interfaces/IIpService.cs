using LocationHunter.Core.Entities;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Services.Interfaces
{
    public interface IIpService
    {
        Task<Location[]> GetLocationsAsync(int count);

        Task SaveLocationAsync(Location location);
    }
}
