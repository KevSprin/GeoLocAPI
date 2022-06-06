using AutoMapper;
using GeoLocAPI.MapperProfiles;
using GeoLocAPI_BAL.Services;
using GeoLocAPI_DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;

namespace GeoLocAPI_BAL.Tests.GeoLocationServiceTests
{
    internal class DeleteGeoLocationByIdTests
    {
        private IMapper mapper;
        private Mock<IGeoLocationFetcherService> mockGeoLocationFetcher;

        [SetUp]
        public void Setup()
        {
            var profile = new GeoLocationDataProfile();
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(profile));
            mapper = new Mapper(mapperConfiguration);
            mockGeoLocationFetcher = new Mock<IGeoLocationFetcherService>();
        }

        [Test]
        public void ShouldSuccessfullyExit()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.DeleteById(It.IsAny<Guid>()));
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            Assert.DoesNotThrowAsync(async () => await service.DeleteById(Guid.NewGuid()));
        }

        [Test]
        public void ShouldThrowException()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.DeleteById(It.IsAny<Guid>())).Throws<Exception>();
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            Assert.ThrowsAsync<Exception>(async () => await service.DeleteById(Guid.NewGuid()));
        }
    }
}
