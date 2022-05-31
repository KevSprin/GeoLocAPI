using GeoLocAPI_Domain.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GeoLocAPI_Domain.DTOs
{
    public class GeoLocationDataDto
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        [Required]
        [HostAddress]
        public string? HostAddress { get; set; }

        [IgnoreDataMember]
        public string? ContinentCode { get; set; }

        [IgnoreDataMember]
        public string? ContinentName { get; set; }

        [IgnoreDataMember]
        public string? CountryCode { get; set; }

        [IgnoreDataMember]
        public string? CountryName { get; set; }

        [IgnoreDataMember]
        public string? RegionCode { get; set; }

        [IgnoreDataMember]
        public string? RegionName { get; set; }

        [IgnoreDataMember]
        public string? Zip { get; set; }

        [IgnoreDataMember]
        public double? Latitude { get; set; }

        [IgnoreDataMember]
        public double? Longitude { get; set; }
    }
}
