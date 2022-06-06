using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Threading.Tasks;
using Flurl.Http.Testing;
using GeoLocAPI_Domain.Models;
using GeoLocAPI_BAL.Services;
using System;

namespace GeoLocAPI_BAL.Tests.GeoLocationFetcherServiceTests
{
    internal class GetGeoLocationDataTests
    {
        private Mock<IConfiguration> mockConfiguration;
        private GeoLocationData geoLocationData;
        private string apiUrl;
        private string apiKey;
        private string hostAddress;

        [SetUp]
        public void Setup()
        {
            hostAddress = "127.0.0.1";
            mockConfiguration = new Mock<IConfiguration>();
            apiUrl = "http://api.ipstack.com/";
            apiKey = "000000000000000";
            mockConfiguration.Setup(config => config["ApiUrl"]).Returns(apiUrl);
            mockConfiguration.Setup(config => config["ApiKey"]).Returns(apiKey);
            geoLocationData = new GeoLocationData { HostAddress = hostAddress };
        }

        [Test]
        public async Task ShouldSuccessfullyReturnGeoLocationData()
        {
            using var httpTest = new HttpTest();
            httpTest.RespondWithJson(geoLocationData);
            var service = new GeoLocationFetcherService(mockConfiguration.Object);

            var result = await service.GetGeoLocationData(geoLocationData);

            Assert.IsInstanceOf<GeoLocationData>(result);
            httpTest.ShouldHaveCalled(apiUrl + hostAddress).WithQueryParam("access_key", apiKey);
        }

        [Test]
        public void ShouldThrowException()
        {
            using var httpTest = new HttpTest();
            httpTest.SimulateException(new Exception());
            var service = new GeoLocationFetcherService(mockConfiguration.Object);

            Assert.ThrowsAsync<Exception>(async () => await service.GetGeoLocationData(geoLocationData));
        }

        [Test]
        public void ShouldThrowExceptionWhenResultIsNull()
        {
            using var httpTest = new HttpTest();
            httpTest.RespondWithJson(null);
            var service = new GeoLocationFetcherService(mockConfiguration.Object);

            Assert.ThrowsAsync<Exception>(async () => await service.GetGeoLocationData(geoLocationData));
        }
    }
}
