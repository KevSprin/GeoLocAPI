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

        public async Task<GeoLocationData> GetGeoLocationData(GeoLocationDataDto geoLocationDataDto)
        {
            var geoLocationData = await _configuration["ApiUrl"].AppendPathSegment(geoLocationDataDto.HostAddress)
                .SetQueryParam("access_key", _configuration["ApiKey"])
                .GetJsonAsync<GeoLocationData>();
            if (geoLocationData.HostAddress == null)
            {
                throw new Exception("Couldn't find geolocation data. Check if the address you provided is valid!");
            }
            geoLocationData.HostAddress = geoLocationDataDto.HostAddress;
            return geoLocationData;
        }
    }
}
