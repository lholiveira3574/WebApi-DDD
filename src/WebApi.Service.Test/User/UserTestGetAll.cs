using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using WebApi.Domain.Dtos.User;
using WebApi.Domain.Interfaces.Services.User;
using Xunit;

namespace WebApi.Service.Test.User
{
    public class UserTestGetAll : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Método GetAll.")]
        public async Task GetAllTest()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();

            //Assert.NotNull(result);
            //Assert.True(result.Count() == 10);

            result.Should().NotBeNull();
            result.Should().HaveCount(10, because: "Existem 10 usuários cadastrados");
        }

        [Fact(DisplayName = "Método GetAll sem usuários cadastrados.")]
        public async Task GetAllEmptyTest()
        {
            var _listResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();

            //Assert.Empty(_resultEmpty);
            //Assert.True(_resultEmpty.Count() == 0);

            _resultEmpty.Should().BeEmpty();
            _resultEmpty.Should().HaveCount(0, because: "Não exite usuários cadastrados");
        }
    }
}