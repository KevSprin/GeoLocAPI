namespace GeoLocAPI_Domain.Models
{
    public class LoginModel
    {
        public Guid Id { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
