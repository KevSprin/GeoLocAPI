using GeoLocAPI.Controllers;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace GeoLocAPI.Tests.GeoLocationControllerTests
{
    internal class GetAllGeoLocationsTests
    {
        [Test]
        public void ShouldReturnOkResult()
        {
            var hostAddress = "127.0.0.1";
            var expectedResultGeoLocationData = new List<GeoLocationDataDto>().AsQueryable();
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.GetAll()).Returns(expectedResultGeoLocationData);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = controller.GetGeoLocation(hostAddress);

            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void ShouldResultIn500()
        {
            var exception = new Exception("Something went wrong");
            var hostAddress = "127.0.0.1";
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.Get(hostAddress)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = controller.GetGeoLocation(hostAddress);

            Assert.IsInstanceOf<ObjectResult>(response);
            var result = (ObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.AreEqual(exception.Message, result.Value);
        }
    }
}
