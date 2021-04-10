using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WebApi.Domain.Interfaces.Services.User;
using Xunit;

namespace WebApi.Service.Test.User
{
    public class UserTestDelete : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName = "Método Delete com Id Válido.")]
        public async Task DeleteTest()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(UserId))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(UserId);

            //Assert.True(deletado);

            deletado.Should().BeTrue(because: "O Usuário foi removido corretamente");

        }

        [Fact(DisplayName = "Método Delete com Id Inválido.")]
        public async Task DeleteTestError()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(Guid.NewGuid());

            //Assert.False(deletado);

            deletado.Should().BeFalse(because: "O Usuário não foi removido corretamente");

        }
    }
}