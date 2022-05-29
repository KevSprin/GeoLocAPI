using AutoMapper;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;

namespace GeoLocAPI.MapperProfiles
{
    public class GeoLocationDataProfile : Profile
    {
        public GeoLocationDataProfile()
        {
            ShouldMapField = fieldInfo => true;
            ShouldMapProperty = propertyInfo => true;
            CreateMap<GeoLocationDataDto, GeoLocationData>();
            CreateMap<GeoLocationData, GeoLocationDataDto>();
        }
    }
}
