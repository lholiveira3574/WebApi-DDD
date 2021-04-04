using System;
using System.Threading.Tasks;
using Moq;
using WebApi.Domain.Interfaces.Services.User;
using Xunit;

namespace WebApi.Service.Test.User
{
    public class UserTestDelete : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName = "Método Delete.")]
        public async Task DeleteTest()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(UserId))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(UserId);
            Assert.True(deletado);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);

        }
    }
}