using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_DAL.Interfaces
{
    public interface IGeoLocationRepository
    {
        Task Create(GeoLocationData geoLocationData);

        GeoLocationData? Get(string hostAddress);

        GeoLocationData? GetById(int id);

        Task Delete(string hostAddress);

        Task DeleteById(int id);
    }
}
