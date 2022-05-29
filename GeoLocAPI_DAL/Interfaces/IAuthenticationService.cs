using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_DAL.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticatedResponse? Authenticate(LoginModelDto login);
    }
}
