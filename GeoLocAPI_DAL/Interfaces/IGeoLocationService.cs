using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_DAL.Interfaces
{
    public interface IGeoLocationService
    {
        Task Create(GeoLocationDataDto geoLocationDataDto);

        Task Delete(string hostAddress);

        Task DeleteById(Guid id);

        GeoLocationDataDto Get(string hostAddress);

        GeoLocationDataDto GetById(Guid id);

        IQueryable<GeoLocationDataDto> GetAll();
    }
}
