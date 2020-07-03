using AutoMapper;
using LocationHunter.Core.Entities;
using LocationHunter.Dal.Repositories.Interfaces;
using LocationHunter.WebApi.IpStackModels;
using LocationHunter.WebApi.Services.Interfaces;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(
            ILocationRepository locationRepository,
            IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<Location[]> GetLocationsAsync(int count)
        {
            return await _locationRepository.GetLocationsAsync(count);
        }

        public async Task SaveLocationAsync(IpStackResponseModel responseModel)
        {
            var location = _mapper.Map<Location>(responseModel);
            await _locationRepository.SaveLocationAsync(location);
        }


    }
}
