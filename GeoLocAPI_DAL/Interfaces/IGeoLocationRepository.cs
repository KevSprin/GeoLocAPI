using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_DAL.Interfaces
{
    public interface IGeoLocationRepository
    {
        Task Create(GeoLocationData geoLocationData);

        GeoLocationData? Get(string hostAddress);

        GeoLocationData? GetById(Guid id);

        IQueryable<GeoLocationData> GetAll();

        Task Delete(string hostAddress);

        Task DeleteById(Guid id);
    }
}
