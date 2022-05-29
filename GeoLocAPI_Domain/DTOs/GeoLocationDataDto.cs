using Newtonsoft.Json;

namespace GeoLocAPI_Domain.DTOs
{
    public class GeoLocationDataDto
    {
        [JsonProperty("ip")]
        public string? HostAddress { get; set; }

        [JsonProperty("continent_code")]
        internal string? ContinentCode { get; set; }

        [JsonProperty("continent_name")]
        internal string? ContinentName { get; set; }

        [JsonProperty("country_code")]
        internal string? CountryCode { get; set; }

        [JsonProperty("country_name")]
        internal string? CountryName { get; set; }

        [JsonProperty("region_code")]
        internal string? RegionCode { get; set; }

        [JsonProperty("region_name")]
        internal string? RegionName { get; set; }

        [JsonProperty("zip")]
        internal string? Zip { get; set; }

        [JsonProperty("latitude")]
        internal double? Latitude { get; set; }

        [JsonProperty("longitude")]
        internal double? Longitude { get; set; }
    }
}
