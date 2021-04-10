using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Application.Controllers;
using WebApi.Domain.Interfaces.Services.User;
using Xunit;

namespace WebApi.Application.Test.User.TestDelete
{
    public class UserTestDelete
    {
        private UsersController _controller;
        [Fact(DisplayName = "Método Delete.")]
        public async Task DeleteTest()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                       .ReturnsAsync(true);

             _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            var resultValue = ((OkObjectResult)result).Value;

            //Assert.True(result is OkObjectResult);
            //Assert.NotNull(resultValue);

            result.Should().BeOfType<OkObjectResult>();
            resultValue.Should().NotBeNull();
            Assert.True((Boolean)resultValue);
        } 
    }
}