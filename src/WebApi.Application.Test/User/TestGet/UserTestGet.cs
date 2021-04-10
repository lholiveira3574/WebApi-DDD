using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Application.Controllers;
using WebApi.Domain.Dtos.User;
using WebApi.Domain.Interfaces.Services.User;
using Xunit;

namespace WebApi.Application.Test.User.TestGet
{
    public class UserTestGet
    {
        private UsersController _controller;
        [Fact(DisplayName = "Método Get.")]
        public async Task UpdateGet()
        {
            var serviceMock = new Mock<IUserService>();
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            var resultValue = ((OkObjectResult)result).Value as UserDto;

            //Assert.True(result is OkObjectResult);
            //Assert.NotNull(resultValue);
            //Assert.Equal(name, resultValue.Name);
            //Assert.Equal(email, resultValue.Email);

            result.Should().BeOfType<OkObjectResult>();
            resultValue.Should().NotBeNull();
            resultValue.Name.Should().Equals(name);
            resultValue.Email.Should().Equals(email);
        }
    }
}