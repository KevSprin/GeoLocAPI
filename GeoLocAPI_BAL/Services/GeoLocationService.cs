using AutoMapper;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI_BAL.Services
{
    public class GeoLocationService : IGeoLocationService
    {
        private readonly IGeoLocationRepository _geoLocationRepository;
        private readonly IGeoLocationFetcherService _client;
        private readonly IMapper _mapper;

        public GeoLocationService(IGeoLocationRepository geoLocationRepository, IGeoLocationFetcherService client, IMapper mapper)
        {
            _geoLocationRepository = geoLocationRepository;
            _client = client;
            _mapper = mapper;
        }

        public async Task Create(GeoLocationDataDto geoLocationDataDto)
        {
            try
            {
                var filledGeoLocationData = await _client.GetGeoLocationData(_mapper.Map<GeoLocationData>(geoLocationDataDto));
                await _geoLocationRepository.Create(filledGeoLocationData);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(string hostAddress)
        {
            try
            {
                await _geoLocationRepository.Delete(hostAddress);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteById(Guid id)
        {
            try
            {
                await _geoLocationRepository.DeleteById(id);
            }
            catch
            {
                throw;
            }
        }

        public GeoLocationDataDto Get(string hostAddress)
        {
            GeoLocationDataDto? foundGeoLocationDataDto;
            try
            {
                var geoLocationData = _geoLocationRepository.Get(hostAddress);
                foundGeoLocationDataDto = _mapper.Map<GeoLocationDataDto>(geoLocationData);
            }
            catch
            {
                throw;
            }
            return foundGeoLocationDataDto;
        }

        public IQueryable<GeoLocationDataDto> GetAll()
        {
            IQueryable<GeoLocationDataDto> geoLocationDataDtos;
            try
            {
                var geoLocationData = _geoLocationRepository.GetAll();
                geoLocationDataDtos = geoLocationData.Select(x => _mapper.Map<GeoLocationDataDto>(x));
            }
            catch
            {
                throw;
            }
            return geoLocationDataDtos;
        }

        public GeoLocationDataDto GetById(Guid id)
        {
            GeoLocationDataDto? foundGeoLocationDataDto;
            try
            {
                var geoLocationData = _geoLocationRepository.GetById(id);
                foundGeoLocationDataDto = _mapper.Map<GeoLocationDataDto>(geoLocationData);
            }
            catch
            {
                throw;
            }
            return foundGeoLocationDataDto;
        }
    }
}
