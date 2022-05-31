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
    internal class GetGeoLocationTests
    {
        [Test]
        public void ShouldReturnOkResult()
        {
            var hostAddress = "127.0.0.1";
            var expectedResultGeoLocationData = new GeoLocationDataDto
            {
                HostAddress = hostAddress
            };
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Get(hostAddress)).Returns(expectedResultGeoLocationData);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = controller.GetGeoLocation(hostAddress);

            Assert.IsInstanceOf(typeof(OkObjectResult), response);
            var result = (OkObjectResult)response;
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResultGeoLocationData, result.Value);
        }

        [Test]
        public void ShouldResultInErrorDueToException()
        {
            var exception = new Exception("Something went wrong");
            var hostAddress = "127.0.0.1";
            var expectedResultGeoLocationData = new GeoLocationDataDto
            {
                HostAddress = hostAddress
            };
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Get(hostAddress)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = controller.GetGeoLocation(hostAddress);

            Assert.IsInstanceOf(typeof(ObjectResult), response);
            var problemDetails = (ObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, problemDetails.StatusCode);
            Assert.AreEqual(exception.Message, problemDetails.Value);
        }
    }
}
