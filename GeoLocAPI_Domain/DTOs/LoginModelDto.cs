using System.ComponentModel.DataAnnotations;

namespace GeoLocAPI_Domain.DTOs
{
    public class LoginModelDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
