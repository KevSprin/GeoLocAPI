using GeoLocAPI_Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GeoLocAPI_Domain.Models
{
    public class HostAddress
    {
        [Required]
        [HostAddress]
        public string Value { get; set; } = string.Empty;
    }
}
