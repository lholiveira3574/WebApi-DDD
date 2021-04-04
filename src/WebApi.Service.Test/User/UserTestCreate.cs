using System.Threading.Tasks;
using Moq;
using WebApi.Domain.Interfaces.Services.User;
using Xunit;

namespace WebApi.Service.Test.User
{
    public class UserTestCreate : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Método Create.")]
        public async Task CreateTest()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);
        }   
    }
}