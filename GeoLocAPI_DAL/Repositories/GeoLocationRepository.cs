using GeoLocAPI_DAL.DataContext;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_DAL.Repositories
{
    public class GeoLocationRepository : IGeoLocationRepository
    {
        private readonly GeoLocDbContext _context;

        public GeoLocationRepository(GeoLocDbContext context)
        {
            _context = context;
        }

        public async Task Create(GeoLocationData geoLocationData)
        {
            try
            {
                _context.GeoLocations?.Add(geoLocationData);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(string hostAddress)
        {
            try
            {
                _context.GeoLocations?.Find(hostAddress);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw;
            }
        }

        public async Task DeleteById(int id)
        {
            try
            {
                var foundGeolocationData = _context.GeoLocations?.First(l => l.Id == id);
                if (foundGeolocationData != null)
                {
                    _context.GeoLocations?.Remove(foundGeolocationData);
                    await _context.SaveChangesAsync();
                }                    
            }
            catch
            {
                throw;
            }
        }

        public GeoLocationData? Get(string hostAddress)
        {
            GeoLocationData? result;
            try
            {
                result = _context.GeoLocations?.First(g => g.HostAddress == hostAddress);
            }
            catch
            {
                throw;
            }
            return result;
        }

        public GeoLocationData? GetById(int id)
        {
            GeoLocationData? result;
            try
            {
                result = _context.GeoLocations?.First(l => l.Id == id);
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
