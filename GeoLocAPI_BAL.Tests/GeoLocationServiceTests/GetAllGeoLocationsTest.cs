using AutoMapper;
using GeoLocAPI.MapperProfiles;
using GeoLocAPI_BAL.Services;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoLocAPI_BAL.Tests.GeoLocationServiceTests
{
    internal class GetAllGeoLocationsTest
    {
        private IMapper mapper;
        private Mock<IGeoLocationFetcherService> mockGeoLocationFetcher;
        private IQueryable<GeoLocationData> geoLocationData;

        [SetUp]
        public void Setup()
        {
            var profile = new GeoLocationDataProfile();
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(profile));
            mapper = new Mapper(mapperConfiguration);
            mockGeoLocationFetcher = new Mock<IGeoLocationFetcherService>();
            geoLocationData = new List<GeoLocationData> { new GeoLocationData(), new GeoLocationData() }.AsQueryable();
        }

        [Test]
        public void ShouldSuccessfullyReturnAllGeoLocationDataDto()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.GetAll()).Returns(geoLocationData);
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            var result = service.GetAll();

            Assert.IsInstanceOf<IQueryable<GeoLocationDataDto>>(result);
            Assert.AreEqual(geoLocationData.Count(), result.Count());
        }

        [Test]
        public void ShouldThrowException()
        {
            var mockRepo = new Mock<IGeoLocationRepository>();
            mockRepo.Setup(x => x.GetAll()).Throws<Exception>();
            var service = new GeoLocationService(mockRepo.Object, mockGeoLocationFetcher.Object, mapper);

            Assert.Throws<Exception>(() => service.GetAll());
        }
    }
}
