using System;
using AutoMapper;
using GeoLocAPI.MapperProfiles;
using GeoLocAPI_BAL.Services;
using GeoLocAPI_DAL.Interfaces;
using GeoLocAPI_Domain.DTOs;
using GeoLocAPI_Domain.Models;
using Moq;
using NUnit.Framework;

namespace GeoLocAPI_BAL.Tests.AuthenticationServiceTests
{
    internal class AuthenticationServiceTests
    {
        private IMapper mapper;
        private LoginModelDto loginModelDto;
        private AuthenticatedResponse authenticatedResponse;

        [SetUp]
        public void Setup()
        {
            var profile = new LoginProfile();
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(profile));
            mapper = new Mapper(mapperConfiguration);
            loginModelDto = new LoginModelDto { Username = "Test", Password = "Password" };
            authenticatedResponse = new AuthenticatedResponse { Token = "testToken" };
        }

        [Test]
        public void ShouldReturnAuthenticatedResponse()
        {
            var mockRepo = new Mock<IAuthenticationRepository>();
            mockRepo.Setup(x => x.Authenticate(It.IsAny<LoginModel>())).Returns(authenticatedResponse);
            var service = new AuthenticationService(mockRepo.Object, mapper);

            var result = service.Authenticate(loginModelDto);

            Assert.IsNotNull(result);
            Assert.AreEqual(authenticatedResponse, result);
        }

        [Test]
        public void ShouldThrowException()
        {
            var exception = new Exception();
            var mockRepo = new Mock<IAuthenticationRepository>();
            mockRepo.Setup(x => x.Authenticate(It.IsAny<LoginModel>())).Throws(exception);
            var service = new AuthenticationService(mockRepo.Object, mapper);

            Assert.Throws<Exception>(() => service.Authenticate(loginModelDto));
        }
    }
}