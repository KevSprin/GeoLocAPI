using AutoMapper;
using GeoLocAPI.MapperProfiles;
using GeoLocAPI_BAL.Services;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;
using Moq;
using NUnit.Framework;
using System;

namespace GeoLocAPI_BAL.Tests.GeoLocationServiceTests
{
    internal class GetGeoLocationByIdTests
    {
        private IMapper mapper;
        private Mock<IGeoLocationFetcherService> mockGeoLocationFetcher;
        private GeoLocationData geoLocationData;

        [SetUp]
        public void Setup()
        {
            var profile = new GeoLocationDataProfile();
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(profile));
            mapper = new Mapper(mapperConfiguration);
            mockGeoLocationFetcher = new Mock<IGeoLocationFetcherService>();
            geoLocationData = new GeoLocationData { HostAddress = "127.0.0.1" };
        }

        [Test]
        public void ShouldSuccessfullyReturnGeoLocationDataDto()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(geoLocationData);
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            var result = service.GetById(Guid.NewGuid());

            Assert.IsInstanceOf<GeoLocationDataDto>(result);
        }

        [Test]
        public void ShouldThrowException()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.GetById(It.IsAny<Guid>())).Throws<Exception>();
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            Assert.Throws<Exception>(() => service.GetById(Guid.NewGuid()));
        }
    }
}
