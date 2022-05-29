using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_DAL.Interfaces
{
    public interface IGeoLocationFetcherService
    {
        Task<GeoLocationDataDto> GetGeoLocationData(HostAddress hostAddress);
    }
}
