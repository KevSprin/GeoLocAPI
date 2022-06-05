using GeoLocAPI.Controllers;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GeoLocAPI.Tests.GeoLocationControllerTests
{
    internal class AddGeoLocationTests
    {
        [Test]
        public async Task ShouldReturnOkResult()
        {
            var geoLocationDataDto = new GeoLocationDataDto() { HostAddress = "127.0.0.1" };
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Create(geoLocationDataDto));
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.AddGeoLocation(geoLocationDataDto);

            Assert.IsInstanceOf<OkResult>(response);
        }

        [Test]
        public async Task ShouldResultIn500()
        {
            var geoLocationDataDto = new GeoLocationDataDto() { HostAddress = "127.0.0.1" };
            var exception = new Exception("Something went wrong");
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Create(geoLocationDataDto)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.AddGeoLocation(geoLocationDataDto);

            Assert.IsInstanceOf<ObjectResult>(response);
            var problemDetails  = (ObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, problemDetails.StatusCode);
            Assert.AreEqual(exception.Message, problemDetails.Value);
        }
    }
}
