using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using GeoLocAPI_DAL.Interfaces;
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

        public async Task<GeoLocationData> GetGeoLocationData(GeoLocationData geoLocationData)
        {
            GeoLocationData? processedGeoLocationData;
            try
            {
                processedGeoLocationData = await _configuration["ApiUrl"].AppendPathSegment(geoLocationData.HostAddress)
                    .SetQueryParam("access_key", _configuration["ApiKey"])
                    .GetJsonAsync<GeoLocationData>();
            }
            catch
            {
                throw new Exception("Failed to send a request for geo location data. Check your internet connection or contact your administrator!");
            }
            if (processedGeoLocationData == null)
            {
                throw new Exception("Couldn't find geolocation data. Check if the address you provided is valid!");
            }
            processedGeoLocationData.HostAddress = geoLocationData.HostAddress;
            return processedGeoLocationData;
        }
    }
}
