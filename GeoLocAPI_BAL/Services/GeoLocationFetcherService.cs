using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_BAL.Services
{
    public class GeoLocationFetcherService : IGeoLocationFetcherService
    {
        private readonly IConfiguration _configuration;
         
        public GeoLocationFetcherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GeoLocationDataDto> GetGeoLocationData(HostAddress hostAddress)
        {
            var geoLocationDataDto = await _configuration["ApiUrl"].AppendPathSegment(hostAddress.Value)
                .SetQueryParam("access_key", _configuration["ApiKey"])
                .GetJsonAsync<GeoLocationDataDto>();
            if (geoLocationDataDto.HostAddress == null)
            {
                throw new Exception("Couldn't find geolocation data. Check if the address you provided is valid!");
            }
            return geoLocationDataDto;
        }
    }
}
