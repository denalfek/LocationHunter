using LocationHunter.Core.Entities;
using LocationHunter.WebApi.IpStackModels;
using System.Threading.Tasks;

namespace LocationHunter.WebApi.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Location[]> GetLocationsAsync(int count);

        Task SaveLocationAsync(IpStackResponseModel responseModel);
    }
}
