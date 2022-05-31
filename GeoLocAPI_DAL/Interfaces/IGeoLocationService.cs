using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_DAL.Interfaces
{
    public interface IGeoLocationService
    {
        Task Create(GeoLocationDataDto geoLocationDataDto);

        Task CreateOwnGeoLocation(GeoLocationDataDto geoLocationDataDto);

        Task Delete(string hostAddress);

        Task DeleteById(int id);

        GeoLocationDataDto Get(string hostAddress);

        GeoLocationDataDto GetById(int id);
    }
}
