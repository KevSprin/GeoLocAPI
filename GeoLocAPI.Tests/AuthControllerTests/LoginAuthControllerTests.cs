using GeoLocAPI.Controllers;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Net;

namespace GeoLocAPI.Tests.AuthControllerTests
{
    internal class LoginAuthControllerTests
    {
        [Test]
        public void ShouldReturnOkResult()
        {
            var locationDataDto = new LoginModelDto() { Username = "Test", Password = "Test123" };
            var authenticatedResponse = new AuthenticatedResponse() { Token = "testtoken" };
            var mockRepo = new Mock<IAuthenticationService>();
            mockRepo.Setup(x => x.Authenticate(locationDataDto)).Returns(authenticatedResponse);
            var controller = new AuthController(mockRepo.Object);

            var response = controller.Login(locationDataDto);

            Assert.IsInstanceOf<OkObjectResult>(response);
            var result = (OkObjectResult)response;
            Assert.AreEqual(authenticatedResponse, result.Value);
        }

        [Test]
        public void ShouldResultIn500()
        {
            var exception = new Exception("Something went wrong");
            var locationDataDto = new LoginModelDto() { Username = "Test", Password = "Test123" };
            var mockRepo = new Mock<IAuthenticationService>();
            mockRepo.Setup(x => x.Authenticate(locationDataDto)).Throws(exception);
            var controller = new AuthController(mockRepo.Object);

            var response = controller.Login(locationDataDto);

            Assert.IsInstanceOf<ObjectResult>(response);
            var result = (ObjectResult)response;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, result.StatusCode);
            Assert.AreEqual(exception.Message, result.Value);
        }

        [Test]
        public void ShouldResultInUnauthorized()
        {
            var locationDataDto = new LoginModelDto() { Username = "Test", Password = "Test123" };
            var mockRepo = new Mock<IAuthenticationService>();
            mockRepo.Setup(x => x.Authenticate(locationDataDto)).Returns(value: null);
            var controller = new AuthController(mockRepo.Object);

            var response = controller.Login(locationDataDto);

            Assert.IsInstanceOf<UnauthorizedResult>(response);
        }
    }
}