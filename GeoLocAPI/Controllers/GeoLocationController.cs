using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeoLocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GeoLocationController : Controller
    {
        private readonly IGeoLocationService _geoLocationService;

        public GeoLocationController(IGeoLocationService geoLocationService)
        {
            _geoLocationService = geoLocationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGeoLocation([FromBody] HostAddress hostAddress)
        {
            try
            {
                await _geoLocationService.Create(hostAddress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet("{hostAddress}")]
        public IActionResult GetGeoLocation(string hostAddress)
        {
            GeoLocationDataDto? result;
            try
            {
                result = _geoLocationService.Get(hostAddress);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGeoLocationById(int id)
        {
            GeoLocationDataDto? result;
            try
            {
                result = _geoLocationService.GetById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete("{hostAddress}")]
        public async Task<IActionResult> DeleteGeoLocation(string hostAddress)
        {
            try
            {
                await _geoLocationService.Delete(hostAddress);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeoLocationById(int id)
        {
            try
            {
                await _geoLocationService.DeleteById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
