using GeoLocAPI_Domain.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GeoLocAPI_Domain.Attributes
{
    internal class HostAddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            GeoLocationDataDto geoLocationData = (GeoLocationDataDto)validationContext.ObjectInstance;

            const string regexIpPattern = @"^((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)(\.(?!$)|$)){4}$";
            const string regexUrlPattern = @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})";
            var regexIp = new Regex(regexIpPattern);
            var regexUrl = new Regex(regexUrlPattern);
            if (string.IsNullOrEmpty(geoLocationData.HostAddress))
            {
                return new ValidationResult("IP address/URL is null");
            }
            if (regexIp.IsMatch(geoLocationData.HostAddress) ||
                regexUrl.IsMatch(geoLocationData.HostAddress))
                return ValidationResult.Success;

            return new ValidationResult("Invalid IP address/URL");
        }
    }
}
