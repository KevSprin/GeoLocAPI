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
                var foundGeoLocationData = _context.GeoLocations?.First(l => l.HostAddress == hostAddress);
                if(foundGeoLocationData != null)
                {
                    _context.GeoLocations?.Remove(foundGeoLocationData);
                    await _context.SaveChangesAsync();
                }
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"GeoLocation record with host address = '{hostAddress}' was not found!");
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
                var foundGeoLocationData = _context.GeoLocations?.First(l => l.Id == id);
                if (foundGeoLocationData != null)
                {
                    _context.GeoLocations?.Remove(foundGeoLocationData);
                    await _context.SaveChangesAsync();
                }
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"GeoLocation record with id = '{id}' was not found!");
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
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"GeoLocation record with host address = '{hostAddress}' was not found!");
            }
            catch
            {
                throw;
            }
            return result;
        }

        public IQueryable<GeoLocationData> GetAll()
        {
            IQueryable<GeoLocationData> result;
            try
            {
                result = _context.Set<GeoLocationData>();
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
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"GeoLocation record with id = '{id}' was not found!");
            }
            catch
            {
                throw;
            }
            return result;
        }
    }
}
