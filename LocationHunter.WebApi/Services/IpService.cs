using LocationHunter.Core.Entities;
using LocationHunter.Dal.Repositories.Interfaces;
using LocationHunter.WebApi.Services.Interfaces;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Services
{
    public class IpService : IIpService
    {
        private readonly ILocationRepository _locationRepository;

        public IpService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<Location[]> GetLocationsAsync(int count)
        {
            return await _locationRepository.GetLocationsAsync(count);
        }

        public async Task SaveLocationAsync(Location location)
        {
            await _locationRepository.SaveLocationAsync(location);
        }


    }
}
