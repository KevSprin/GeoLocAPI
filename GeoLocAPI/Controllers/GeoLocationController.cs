using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using HashidsNet;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GeoLocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GeoLocationController : Controller
    {
        private readonly IGeoLocationService _geoLocationService;

        public GeoLocationController(IGeoLocationService geoLocationService)
        {
            _geoLocationService = geoLocationService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGeoLocation([FromBody] GeoLocationDataDto geoLocationDataDto)
        {
            try
            {
                await _geoLocationService.Create(geoLocationDataDto);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            return Ok();
        }

        [HttpGet("[action]/{hostAddress}")]
        public IActionResult GetGeoLocation([FromRoute] string hostAddress)
        {
            GeoLocationDataDto? result;
            try
            {
                result = _geoLocationService.Get(hostAddress);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("[action]/{id:guid}")]
        public IActionResult GetGeoLocationById([FromRoute] Guid id)
        {
            GeoLocationDataDto? result;
            try
            {
                result = _geoLocationService.GetById(id);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetAllGeoLocations()
        {
            IQueryable result;
            try
            {
                result = _geoLocationService.GetAll();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            return Ok(result);
        }

        [HttpDelete("[action]/{hostAddress}")]
        public async Task<IActionResult> DeleteGeoLocation([FromRoute]string hostAddress)
        {
            try
            {
                await _geoLocationService.Delete(hostAddress);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            return Ok();
        }

        [HttpDelete("[action]/{id:guid}")]
        public async Task<IActionResult> DeleteGeoLocationById([FromRoute] Guid id)
        {
            try
            {
                await _geoLocationService.DeleteById(id);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            return Ok();
        }
    }
}
