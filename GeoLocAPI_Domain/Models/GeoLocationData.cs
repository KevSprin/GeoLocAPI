namespace GeoLocAPI_Domain.Models
{
    public class GeoLocationData
    {
        public int Id { get; set; }

        public string? HostAddress { get; set; }

        public string? ContinentCode { get; set; }

        public string? ContinentName { get; set; }

        public string? CountryCode { get; set; }

        public string? CountryName { get; set; }

        public string? RegionCode { get; set; }

        public string? RegionName { get; set; }

        public string? Zip { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }
}
