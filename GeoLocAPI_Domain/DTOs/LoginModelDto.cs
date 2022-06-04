using System.ComponentModel.DataAnnotations;

namespace GeoLocAPI_Domain.DTOs
{
    public class LoginModelDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
