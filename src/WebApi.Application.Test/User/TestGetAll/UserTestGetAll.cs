using System;
using System.Collections.Generic;
using System.Linq;
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
    public class UserTestGetAll
    {
        private UsersController _controller;
        [Fact(DisplayName = "Método GetAll.")]
        public async Task UpdateGetAll()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDto>
                {
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    },
                    new UserDto
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreateAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.GetAll();
            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;

            //Assert.True(result is OkObjectResult);
            //Assert.NotNull(resultValue);
            //Assert.True(resultValue.Count() == 2);

            result.Should().BeOfType<OkObjectResult>();
            resultValue.Should().NotBeNull();
            resultValue.Should().HaveCount(2, because: "Existem 2 usuários cadastrados");
        }
    }
}