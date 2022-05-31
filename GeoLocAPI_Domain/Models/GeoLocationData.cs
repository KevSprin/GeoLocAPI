using Newtonsoft.Json;

namespace GeoLocAPI_Domain.Models
{
    public class GeoLocationData
    {
        public int Id { get; set; }

        [JsonProperty("ip")]
        public string? HostAddress { get; set; }

        [JsonProperty("continent_code")]
        public string? ContinentCode { get; set; }

        [JsonProperty("continent_name")]
        public string? ContinentName { get; set; }

        [JsonProperty("country_code")]
        public string? CountryCode { get; set; }

        [JsonProperty("country_name")]
        public string? CountryName { get; set; }

        [JsonProperty("region_code")]
        public string? RegionCode { get; set; }

        [JsonProperty("region_name")]
        public string? RegionName { get; set; }

        [JsonProperty("zip")]
        public string? Zip { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }
    }
}
