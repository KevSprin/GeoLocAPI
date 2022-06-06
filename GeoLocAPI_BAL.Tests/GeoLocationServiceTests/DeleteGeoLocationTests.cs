using AutoMapper;
using GeoLocAPI.MapperProfiles;
using GeoLocAPI_BAL.Services;
using GeoLocAPI_DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace GeoLocAPI_BAL.Tests.GeoLocationServiceTests
{
    internal class DeleteGeoLocationTests
    {
        private IMapper mapper;
        private Mock<IGeoLocationFetcherService> mockGeoLocationFetcher;
        private string hostAddress;

        [SetUp]
        public void Setup()
        {
            var profile = new GeoLocationDataProfile();
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(profile));
            mapper = new Mapper(mapperConfiguration);
            mockGeoLocationFetcher = new Mock<IGeoLocationFetcherService>();
            hostAddress = "127.0.0.1";
        }

        [Test]
        public void ShouldSuccessfullyExit()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.Delete(It.IsAny<string>()));
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            Assert.DoesNotThrowAsync(async () => await service.Delete(hostAddress));
        }

        [Test]
        public void ShouldThrowException()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.Delete(It.IsAny<string>())).Throws<Exception>();
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            Assert.ThrowsAsync<Exception>(async () => await service.Delete(hostAddress));
        }
    }
}
