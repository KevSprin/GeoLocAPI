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
    internal class DeleteGeoLocationByIdTests
    {
        [Test]
        public async Task ShouldReturnOkResult()
        {
            var id = Guid.NewGuid();
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.DeleteById(id));
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.DeleteGeoLocationById(id);

            Assert.IsInstanceOf<OkResult>(response);
        }

        [Test]
        public async Task ShouldResultIn500()
        {
            var exception = new Exception("Something went wrong");
            var id = Guid.NewGuid();
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.DeleteById(id)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.DeleteGeoLocationById(id);

            Assert.IsInstanceOf<ObjectResult>(response);
            var result = (ObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.AreEqual(exception.Message, result.Value);
        }

        [Test]
        public async Task ShouldResultInNotFound()
        {
            var exception = new InvalidOperationException("Something went wrong");
            var id = Guid.NewGuid();
            var mockRepo = new Mock<IGeoLocationService>();
            mockRepo.Setup(x => x.DeleteById(id)).Throws(exception);
            var controller = new GeoLocationController(mockRepo.Object);

            var response = await controller.DeleteGeoLocationById(id);

            Assert.IsInstanceOf<NotFoundObjectResult>(response);
            var result = (NotFoundObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.AreEqual(exception.Message, result.Value);
        }
    }
}
