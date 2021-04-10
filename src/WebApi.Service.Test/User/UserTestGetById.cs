using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WebApi.Domain.Dtos.User;
using WebApi.Domain.Interfaces.Services.User;
using Xunit;

namespace WebApi.Service.Test.User
{
    public class UserTestGetById : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Método GetById.")]
        public async Task GetByIdTest()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(UserId)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(UserId);

            // Assert.NotNull(result);
            // Assert.True(result.Id == UserId);
            // Assert.Equal(UserName, result.Name);

            result.Should().NotBeNull();
            result.Id.Should().Equals(UserId);
            result.Name.Should().Equals(UserName);

        }

        [Fact(DisplayName = "Método GetById Null.")]
        public async Task GetByIdNullTest()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(UserId);
            
            //Assert.Null(_record);

            _record.Should().BeNull();
        }
        
    }
}