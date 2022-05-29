using GeoLocAPI_DAL.DataContext;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GeoLocAPI_DAL.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly GeoLocDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationRepository(GeoLocDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public AuthenticatedResponse? Authenticate(LoginModel login)
        {
            AuthenticatedResponse? response = null;
            try
            {
                var foundLogin = _context.LoginModels?.First(l => l.Username == login.Username);
                if (foundLogin == null) return null;
                if (BCrypt.Net.BCrypt.Verify(login.Password, foundLogin.Password))
                {
                    var issuers = _configuration.GetSection("JWT:Issuers").Get<List<string>>();
                    var audiences = _configuration.GetSection("JWT:Audiences").Get<List<string>>();
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: issuers[1],
                        audience: audiences[1],
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    response = new AuthenticatedResponse() { Token = tokenString };
                }
            }
            catch
            {
                throw;
            }
            return response;
        }
    }
}
