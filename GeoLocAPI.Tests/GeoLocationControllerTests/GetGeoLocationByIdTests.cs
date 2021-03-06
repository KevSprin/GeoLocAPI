using GeoLocAPI.Controllers;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Net;

namespace GeoLocAPI.Tests.GeoLocationControllerTests
{
    internal class GetGeoLocationByIdTests
    {
        [Test]
        public void ShouldReturnOkResult()
        {
            var id = Guid.NewGuid();
            var expectedResultGeoLocationData = new GeoLocationDataDto
            {
                Id = id,
                HostAddress = "127.0.0.1"
            };
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.GetById(id)).Returns(expectedResultGeoLocationData);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = controller.GetGeoLocationById(id);

            Assert.IsInstanceOf<OkObjectResult>(response);
            var result = (OkObjectResult)response;
            Assert.AreEqual(expectedResultGeoLocationData, result.Value);
        }

        [Test]
        public void ShouldResultIn500()
        {
            var id = Guid.NewGuid();
            var exception = new Exception("Something went wrong");
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.GetById(id)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = controller.GetGeoLocationById(id);

            Assert.IsInstanceOf<ObjectResult>(response);
            var result = (ObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.AreEqual(exception.Message, result.Value);
        }

        [Test]
        public void ShouldResultInNotFound()
        {
            var id = Guid.NewGuid();
            var exception = new InvalidOperationException("Couldn't find element in DB");
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.GetById(id)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = controller.GetGeoLocationById(id);

            Assert.IsInstanceOf<NotFoundObjectResult>(response);
            var result = (NotFoundObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(exception.Message, result.Value);
        }
    }
}
