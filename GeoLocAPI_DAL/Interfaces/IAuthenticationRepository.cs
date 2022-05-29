using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_DAL.Interfaces
{
    public interface IAuthenticationRepository
    {
        AuthenticatedResponse? Authenticate(LoginModel login);
    }
}
