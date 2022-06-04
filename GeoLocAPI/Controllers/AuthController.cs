using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] LoginModelDto user)
        {
            AuthenticatedResponse? response;
            try
            {
                response = _authenticationService.Authenticate(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
    }
}
