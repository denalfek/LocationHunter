using LocationHunter.Core.Entities;
using System.Threading.Tasks;

namespace LocationHunter.Dal.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location[]> GetLocationsAsync(int count);

        Task SaveLocationAsync(Location location);
    }
}
