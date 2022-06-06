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
    internal class CreateGeoLocationTests
    {
        private IMapper mapper;
        private GeoLocationDataDto geoLocationDataDto;
        private GeoLocationData geoLocationData;

        [SetUp]
        public void Setup()
        {
            var profile = new GeoLocationDataProfile();
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(profile));
            mapper = new Mapper(mapperConfiguration);
            geoLocationDataDto = new GeoLocationDataDto { HostAddress = "127.0.0.1" };
            geoLocationData = new GeoLocationData { HostAddress = "127.0.0.1" };
        }

        [Test]
        public void ShouldSuccessfullyExit()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.Create(It.IsAny<GeoLocationData>()));
            var mockGeoLocationFetcher = new Mock<IGeoLocationFetcherService>();
            mockGeoLocationFetcher.Setup(x => x.GetGeoLocationData(It.IsAny<GeoLocationData>())).ReturnsAsync(geoLocationData);
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            Assert.DoesNotThrowAsync(async () => await service.Create(geoLocationDataDto));
        }

        [Test]
        public void ShouldThrowException()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.Create(It.IsAny<GeoLocationData>()));
            var mockGeoLocationFetcher = new Mock<IGeoLocationFetcherService>();
            mockGeoLocationFetcher.Setup(x => x.GetGeoLocationData(It.IsAny<GeoLocationData>())).Throws<Exception>();
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            Assert.ThrowsAsync<Exception>(async () => await service.Create(geoLocationDataDto));
        }
    }
}
