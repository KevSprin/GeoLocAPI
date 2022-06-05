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
    internal class DeleteGeoLocationTests
    {
        [Test]
        public async Task ShouldReturnOkResult()
        {
            var hostAddress = "127.0.0.1";
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Delete(hostAddress));
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.DeleteGeoLocation(hostAddress);

            Assert.IsInstanceOf<OkResult>(response);
        }

        [Test]
        public async Task ShouldResultIn500()
        {
            var exception = new Exception("Something went wrong");
            var hostAddress = "127.0.0.1";
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Delete(hostAddress)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.DeleteGeoLocation(hostAddress);

            Assert.IsInstanceOf<ObjectResult>(response);
            var result = (ObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.AreEqual(exception.Message, result.Value);
        }

        [Test]
        public async Task ShouldResultInNotFound()
        {
            var exception = new InvalidOperationException("Something went wrong");
            var hostAddress = "127.0.0.1";
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Delete(hostAddress)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.DeleteGeoLocation(hostAddress);

            Assert.IsInstanceOf<NotFoundObjectResult>(response);
            var result = (NotFoundObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(exception.Message, result.Value);
        }
    }
}
