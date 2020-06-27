using LocationHunter.Core.Entities;
using LocationHunter.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LocationHunter.Dal.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly LocationHunterDbContex _db;

        public LocationRepository(LocationHunterDbContex db)
        {
            _db = db;
        }

        public async Task<Location[]> GetLocationsAsync(int count)
        {
            return await _db.Locations.Take(count).ToArrayAsync();
        }

        public async Task SaveLocationAsync(Location location)
        {
            await _db.Locations.AddAsync(location);
            await _db.SaveChangesAsync();
        }
    }
}
