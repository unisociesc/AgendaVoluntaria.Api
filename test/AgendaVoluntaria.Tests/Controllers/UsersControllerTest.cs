﻿using AgendaVoluntaria.Api.Configuration;
using AgendaVoluntaria.Api.Models;
using AgendaVoluntaria.Api.Models.Interfaces;
using AgendaVoluntaria.Api.Services.Interfaces;
using AgendaVoluntaria.Api.Utils;
using AgendaVoluntaria.Api.Utils.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AgendaVoluntaria.Api.Controllers
{
    public class UsersControllerTest
    {
        protected UsersController ControllerUnderTest { get; }
        private readonly INotifier notifierMock;
        private readonly IMapper _mapper;
        protected Mock<IUserService> UserServiceMock { get; }

        public UsersControllerTest()
        {
            UserServiceMock = new Mock<IUserService>();
            notifierMock = new Notifier();
            _mapper = new Mapper(typeof(AutoMapperConfiguration));
            ControllerUnderTest = new UsersController(UserServiceMock.Object, _mapper, notifierMock);
        }


        public class GetAllAsync : UsersControllerTest
        {
            [Fact]
            public async Task Should_return_OkObjectResult_with_users()
            {
                //Arrange
                var expectedUsers = new User[]
                {
                    new User { Name = "Gabriel Meyer", Email = "ghmeyer0@gmail.com"},
                    new User { Name = "Renato Rezende", Email = "rrschiavo@gmail.com"}
                };
                UserServiceMock
                    .Setup(x => x.GetAllAsync())
                    .ReturnsAsync(expectedUsers);

                //Act
                var result = await ControllerUnderTest.GetAllAsync();

                //Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedUsers, okResult.Value);
            }
        }

        public class GetOneByIdAsync : UsersControllerTest
        {
            [Fact]
            public async Task Deve_retornar_OkObjectResult_com_o_usuario_esperado()
            {
                // Arrange 
                Guid id = Guid.NewGuid();
                var expectedUser = new User
                {
                    Id = id,
                    Email = "ghmeyer0@gmail.com",
                    Name = "Gabriel Helko Meyer",
                    Password = "aaaaa"
                };
                UserServiceMock
                    .Setup(x => x.GetByIdAsync(id))
                    .ReturnsAsync(expectedUser);

                // Act
                var result = await ControllerUnderTest.GetByIdAsync(id);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedUser, okResult.Value);

            }

            [Fact]
            public async Task Deve_retornar_OkObjectResult_vazio()
            {
                // Arrange
                Guid id = Guid.NewGuid();
                User expectedValue = null;
                UserServiceMock
                    .Setup(x => x.GetByIdAsync(id))
                    .ReturnsAsync(expectedValue);

                // Act
                var result = await ControllerUnderTest.GetByIdAsync(id);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Null(okResult.Value);
            }
        }

        public class UpdateAsync : UsersControllerTest
        {
        }
    }
}
