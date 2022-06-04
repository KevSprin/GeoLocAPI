using GeoLocAPI_Domain.Attributes;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GeoLocAPI_Domain.DTOs
{
    public class GeoLocationDataDto
    {
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }

        [Required]
        [HostAddress]
        public string? HostAddress { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? ContinentCode { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? ContinentName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? CountryCode { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? CountryName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? RegionCode { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? RegionName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Zip { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public double? Latitude { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public double? Longitude { get; set; }
    }
}
