using AutoMapper;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_BAL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        public AuthenticatedResponse? Authenticate(LoginModelDto login)
        {
            AuthenticatedResponse? authenticatedResponse;
            try
            {
                authenticatedResponse = _authenticationRepository.Authenticate(_mapper.Map<LoginModel>(login));
            }
            catch
            {
                throw;
            }
            return authenticatedResponse;
        }
    }
}
