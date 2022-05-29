using GeoLocAPI.Controllers;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace GeoLocAPI.Tests
{
    internal class GeoLocationControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async void ShouldReturnOkResult()
        {
            var hostAddress = new HostAddress() { Value = "127.0.0.1" };
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Create(hostAddress));
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.AddGeoLocation(hostAddress);

            Assert.IsInstanceOf(typeof(OkResult), response);
        }

        [Test]
        public async Task ShouldReturnBadRequestResultDueToException()
        {
            var hostAddress = new HostAddress() { Value = "127.0.0.1" };
            var exception = new Exception("Something went wrong");
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Create(hostAddress)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.AddGeoLocation(hostAddress);

            Assert.IsInstanceOf(typeof(BadRequestObjectResult), response);
            var badRequestObjestResult  = (BadRequestObjectResult)response;
            Assert.AreEqual(exception.Message, badRequestObjestResult.Value);
        }
    }
}
