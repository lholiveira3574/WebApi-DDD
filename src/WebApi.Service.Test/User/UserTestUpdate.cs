using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WebApi.Domain.Interfaces.Services.User;
using Xunit;

namespace WebApi.Service.Test.User
{
    public class UserTestUpdate : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Método Update.")]
        [Trait("Create", "UserEntity")]
        public async Task UpdateTest()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            await _service.Post(userDtoCreate);
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(userDtoUpdate);

            // Assert.NotNull(resultUpdate);
            // Assert.Equal(UserNameChanged, resultUpdate.Name);
            // Assert.Equal(UserEmailChanged, resultUpdate.Email);

            resultUpdate.Should().NotBeNull();
            resultUpdate.Name.Should().Equals(UserNameChanged);
            resultUpdate.Email.Should().Equals(UserEmailChanged);
        }
    }
}